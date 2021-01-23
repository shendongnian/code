    public class WorldRegion
    {
        public virtual ICollection<WorldRegionResource> WorldRegionResources { get; set; }
    }
    public class WorldRegionResource
    {
        [ForeignKey(nameof(Culture))]
        public int CultureId { get; set; }
        public virtual Culture Culture { get; set; }
    }
    public class Culture
    {
        public string CultureName { get; set; }
    }
