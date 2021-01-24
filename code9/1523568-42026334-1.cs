    public class Alternative
    {
        public string transcript { get; set; }
        public double confidence { get; set; }
    }
    public class Result
    {
        public List<Alternative> alternative { get; set; }
        public bool final { get; set; }
    }
    public class RootObject
    {
        public List<Result> result { get; set; }
        public int result_index { get; set; }
    }
