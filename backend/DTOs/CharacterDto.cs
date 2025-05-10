﻿namespace BackPruebaTecnicaCarsales.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public required string Species { get; set; }
        public required string Type { get; set; }
        public required string Gender { get; set; }
        public required Origin Origin { get; set; }
        public required Location Location { get; set; }
        public required string Image { get; set; }
        public required List<string> Episode { get; set; }
        public required string Url { get; set; }
        public DateTime Created { get; set; }
    }

    public class Origin
    {
        public required string Name { get; set; }
        public required string Url { get; set; }
    }

    public class Location
    {
        public required string Name { get; set; }
        public required string Url { get; set; }
    }
}
