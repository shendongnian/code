    public class Section
    {
        public int Id { get; set; } 
        public string SectionName { get; set; }
        public float? IsActive { get; set; }
        public float? IsDeleted { get; set; }
        public string LocationName { get; set; }
        public string DivisionName { get; set; }
    
        [JsonProperty("SubDivision")]
        public string SubDivisionName { get; set; }
        public string CircleName { get; set; }
    
        [JsonProperty("City")]
        public string CityName { get; set; }
    }
