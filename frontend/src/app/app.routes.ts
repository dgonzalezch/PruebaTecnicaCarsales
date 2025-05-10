import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'episodes-list',
    pathMatch: 'full'
  },
  {
    path: 'episodes-list',
    loadComponent: () => import('./pages/episodes/components/episode-list/episode-list.component').then(c => c.EpisodeListComponent)
  }
];
