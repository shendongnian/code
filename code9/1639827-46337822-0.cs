    public class Dataset
    {
        public string label { get; set; }
        public List<int> data { get; set; }
        public List<string> backgroundColor { get; set; }
        public int borderWidth { get; set; }
    }
    
    public class RootObject
    {
        public List<Dataset> datasets { get; set; }
    }
