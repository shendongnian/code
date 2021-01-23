    public class EditVM
    {
        public int FooID { get; set; }
        public List<BarVM> Bars { get; set; }
    }
    public class BarVM
    {
        public string Name { get; set; }
        public List<BarVersionVM> Versions { get; set; }
    }
    public class BarVersionVM
    {
        public int ID { get; set; }
        public string Name { get; set; } // not clear where you use this property
        public string Version { get; set; }
        public bool IsSupported { get; set; }
    }
