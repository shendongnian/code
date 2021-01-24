    public class tblApplications
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public tblLevel5s tblLevel5 { get; set; }
        
    }
    public class tblLevel5s
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public tblLevel4s tblLevel4 { get; set; }
    }
    public class tblLevel4s
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
