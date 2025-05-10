import { CharacterDto } from "./character.model";

export interface EpisodeDto {
  id: number;
  name: string;
  air_date: string;
  episode: string;
  charactersDetails: CharacterDto[];
  created: string;
}

export interface PagedResponse<T> {
  currentPage: number;
  totalPages: number;
  totalItems: number;
  items: T[];
}
