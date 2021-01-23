    public class Box
    {
        public int box_id { get; set; }
        public string box_name { get; set; }
        public object box_group { get; set; }
    }
    public class Datum
    {
        public int id { get; set; }
        public int business_id { get; set; }
        public string business_name { get; set; }
        public List<Box> boxes { get; set; }
    }
    public class RootObject
    {
        public List<Datum> data { get; set; }
    }
