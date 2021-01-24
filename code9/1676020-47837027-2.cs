    public class Datum
    {
        public int FarmID { get; set; }
        public string FarmName { get; set; }
        public string FarmerSurname { get; set; }
        public string FarmerForename { get; set; }
    }
    public class Content
    {
        public int code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public List<Datum> data { get; set; }
    }
