    public class Result
    {
        public double O { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public double C { get; set; }
        public double V { get; set; }
        public string T { get; set; }
        public double BV { get; set; }
    }
    public class RootObject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Result> result { get; set; }
    }
