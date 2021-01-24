    public class ToursViewModel
    {
        public string RegionName { get; set; }
        public string ImageName {get; set; }  
    }
    public class IndexAdminViewModel
    {
        public string UserName { get; set; }
        public IEnumerable<ToursViewModel> Tours {get;set;}
    }
