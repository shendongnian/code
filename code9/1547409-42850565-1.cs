    public class Data
    {
        public string booking_id { get; set; }
        public double booking_amount { get; set; }
        public double room_charges { get; set; }
        public double meal_charges { get; set; }
        public double inclusion_charges { get; set; }
        public double taxes { get; set; }
        public string status { get; set; }
    }
    public class RootObject
    {
        public int status { get; set; }
        public Data data { get; set; }
    }
