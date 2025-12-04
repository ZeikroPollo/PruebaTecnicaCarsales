export interface EpisodeDto {
  id: number;
  name: string;
  airDate: string;
  episodeCode: string;
}

export interface EpisodePageDto {
  page: number;
  totalPages: number;
  totalCount: number;
  items: EpisodeDto[];
}
