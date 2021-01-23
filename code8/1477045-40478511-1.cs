    public class Site // should be singular, not plural - its describes one object
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public bool IsCheck { get; set; }
        public List<Room> Rooms { get; set; }
    }
