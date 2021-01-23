    public class Site
    {
        public int SiteID { get; set; }
        [Column("SiteName")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Location> Locations { get; internal set; }
    }
    
    public class Location
    {
        public int LocationID { get; set; }
        [Column("LocationName")]
        public string Name { get; set; }
        [Column("LocationDescription")]
        public string Description { get; set; }
        public Guid ReportingID { get; set; }
        [Column("LocationSiteID")]
        public int SiteID { get; set; }
    }
