import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { EpisodeService } from '../../services/episode.service';
import { LoadingComponent } from '../../../../shared/components/loading/loading.component';
import { SearchFilterPipe } from '../../../../shared/pipes/search-filter-pipe.pipe';

@Component({
  standalone: true,
  selector: 'app-episode-list',
  imports: [CommonModule, DatePipe, LoadingComponent, SearchFilterPipe],
  templateUrl: './episode-list.component.html',
  styleUrls: ['./episode-list.component.scss']
})
export class EpisodeListComponent implements OnInit {
  public episodeService = inject(EpisodeService);
  search = signal<string>('');

  ngOnInit(): void {
    this.episodeService.getEpisodes(this.episodeService.currentPage());
  }

  prevPage = () => this.episodeService.prevPage();
  nextPage = () => this.episodeService.nextPage();

  filteredEpisodes = computed(() =>
    this.episodeService.episodes().filter(e =>
      e.name.toLowerCase().includes(this.search().toLowerCase())
    )
  );
}
