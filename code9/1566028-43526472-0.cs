    public class Root
    {
        public List<Structure> structure;
    }
    public class Structure
    {
        public string name { get; set; }
        public string type { get; set; }
        public string required { get; set; }
        public string unique { get; set; }
        public string canRead { get; set; }
        public string canUpdate { get; set; }
        public string canCreate { get; set; }
    }
