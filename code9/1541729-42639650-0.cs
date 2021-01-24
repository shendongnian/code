    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }
    public class Class1
    {
        public Mountain[] Mountains { get; set; }
    }
    public class Mountain
    {
        public string MtName { get; set; }
        public int Masl { get; set; }
        public int Difficulty { get; set; }
        public int Island { get; set; }
    }
