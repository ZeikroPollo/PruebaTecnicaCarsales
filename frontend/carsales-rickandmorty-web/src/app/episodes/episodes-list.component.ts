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

  // Signals con la info de la página
  currentPage = signal(1);
  totalPages = signal(1);
  episodes = signal<EpisodeDto[]>([]);

  // Inyecta el servicio
  private readonly episodesService = inject(EpisodesService);

  // Inyecta la plataforma para saber si esta en navegador o en SSR
  private readonly platformId = inject(PLATFORM_ID);

  ngOnInit(): void {
    // solo carga datos si esta en el navegador
    if (isPlatformBrowser(this.platformId)) {
      this.loadEpisodes();
    }
  }

  loadEpisodes(): void {
    this.episodesService.getEpisodes(this.currentPage()).subscribe({
      next: (resp) => {
        this.totalPages.set(resp.totalPages);
        this.episodes.set(resp.items);
      },
      error: (err) => {
        console.error('Error al cargar episodios', err);
      }
    });
  }

  nextPage(): void {
    if (this.currentPage() < this.totalPages()) {
      this.currentPage.update(p => p + 1);
      this.loadEpisodes();
    }
  }

  prevPage(): void {
    if (this.currentPage() > 1) {
      this.currentPage.update(p => p - 1);
      this.loadEpisodes();
    }
  }
}