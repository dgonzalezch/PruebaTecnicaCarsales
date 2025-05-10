import { inject, Injectable, signal, computed, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, timeout } from 'rxjs/operators';
import { EMPTY } from 'rxjs';
import { EpisodeDto, PagedResponse } from '../models/episode.model';
import { environment } from '../../../../environments/environment';
import { isPlatformBrowser } from '@angular/common';

@Injectable({ providedIn: 'root' })
export class EpisodeService {
  private http = inject(HttpClient);
  private readonly apiUrl = '/api/episodes';
  currentPage = signal(1);
  response = signal<PagedResponse<EpisodeDto> | null>(null);
  error = signal<string | null>(null);
  loading = signal(false);
  readonly episodes = computed(() => this.response()?.items ?? []);
  readonly totalPages = computed(() => this.response()?.totalPages ?? 0);

  constructor(@Inject(PLATFORM_ID) private platformId: Object) { }

  getEpisodes(page: number): void {
    this.error.set(null);
    this.loading.set(true); // comienza carga

    const cacheKey = `episodes_page_${page}`;
    if (isPlatformBrowser(this.platformId)) {
      const cached = sessionStorage.getItem(cacheKey);
      if (cached) {
        const parsed: PagedResponse<EpisodeDto> = JSON.parse(cached);
        this.response.set(parsed);
        this.currentPage.set(page);
        this.loading.set(false); // finaliza carga desde caché
        return;
      }
    }

    this.http.get<PagedResponse<EpisodeDto>>(`${this.apiUrl}?page=${page}`).pipe(
      timeout(environment.responseTimeout),
      catchError((err) => {
        this.loading.set(false); // finaliza carga con error
        if (err.name === 'TimeoutError') {
          this.error.set('La solicitud ha excedido el tiempo de espera.');
        } else {
          this.error.set('Error al obtener episodios');
        }
        return EMPTY;
      })
    ).subscribe((res) => {
      this.response.set(res);
      this.currentPage.set(page);
      this.loading.set(false); // finaliza carga exitosa

      if (isPlatformBrowser(this.platformId)) {
        sessionStorage.setItem(cacheKey, JSON.stringify(res));
      }
    });
  }

  nextPage(): void {
    if (this.currentPage() < this.totalPages()) {
      this.getEpisodes(this.currentPage() + 1);
    }
  }

  prevPage(): void {
    if (this.currentPage() > 1) {
      this.getEpisodes(this.currentPage() - 1);
    }
  }
}
