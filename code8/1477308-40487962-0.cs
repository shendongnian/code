    public class Resource
    {
        public string ResourceId { get; set; }
        public string MSPSLogin { get; set; }
        public string Email { get; set; }
    }
    public class Resources
    {
        public List<Resource> Resource { get; set; }
    }
    public class Example
    {
        public Resources Resources { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedByApp { get; set; }
    }
