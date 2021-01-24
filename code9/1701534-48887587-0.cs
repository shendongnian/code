    public class DataObject // name it properly
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string message { get; set; }
        public string uid { get; set; }
    }
    public class Data
    {
        public List<DataObject> data { get; set; }
    }
