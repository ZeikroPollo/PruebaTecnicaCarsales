import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EpisodePageDto } from '../models/episode.model';

@Injectable({
  providedIn: 'root'
})
export class EpisodesService {

  // URL del BFF (.NET)
  private readonly baseUrl = 'https://localhost:7106/api/episodes';

  // 👇 inyecta HttpClient y lo guarda en la propiedad "http"
  constructor(private http: HttpClient) {}

  /**
   * Obtiene una página de episodios desde el BFF.
   */
  getEpisodes(page: number): Observable<EpisodePageDto> {
    const safePage = page < 1 ? 1 : page;

    return this.http.get<EpisodePageDto>(this.baseUrl, {
      params: { page: safePage }
    });
  }
}