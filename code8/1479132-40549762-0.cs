    public class Rootobject
    {
        public System.Collections.Generic.IDictionary<string, panel> panels { get; set; }
    }
    public class panel
    {
        public string label_value { get; set; }
        public row[] rows { get; set }
    }
    public class row
    {
        public string name { get; set; }
        public string label_value { get; set; }
        public string label { get; set; }
        public string type { get; set; }
        public string required { get; set; }
        public string CanBeSecuredForCreate { get; set; }
        public string CanBeSecuredForRead { get; set; }
        public string CanBeSecuredForUpdate { get; set; }
    }
