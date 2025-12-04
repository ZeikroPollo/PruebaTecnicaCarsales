import { CommonModule, isPlatformBrowser } from '@angular/common';
import { Component, inject, PLATFORM_ID, signal } from '@angular/core';
import { EpisodesService } from '../services/episodes.service';
import { EpisodeDto } from '../models/episode.model';

@Component({
  selector: 'app-episodes-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './episodes-list.component.html',
  styleUrl: './episodes-list.component.css'
})
export class EpisodesListComponent {

  currentPage = signal(1);
  totalPages = signal(1);
  episodes = signal<EpisodeDto[]>([]);

  // estados nuevos
  loading = signal(false);
  error = signal<string | null>(null);

  private readonly episodesService = inject(EpisodesService);
  private readonly platformId = inject(PLATFORM_ID);

  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      this.loadEpisodes();
    }
  }

  loadEpisodes(): void {
    this.loading.set(true);
    this.error.set(null);

    this.episodesService.getEpisodes(this.currentPage()).subscribe({
      next: (resp) => {
        this.totalPages.set(resp.totalPages);
        this.episodes.set(resp.items);
        this.loading.set(false);
      },
      error: (err) => {
        console.error('Error al cargar episodios', err);
        this.error.set('No se pudieron cargar los episodios. Intenta nuevamente más tarde.');
        this.loading.set(false);
      }
    });
  }

  nextPage(): void {
    if (this.currentPage() < this.totalPages() && !this.loading()) {
      this.currentPage.update(p => p + 1);
      this.loadEpisodes();
    }
  }

  prevPage(): void {
    if (this.currentPage() > 1 && !this.loading()) {
      this.currentPage.update(p => p - 1);
      this.loadEpisodes();
    }
  }
}
