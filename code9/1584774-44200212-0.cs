    public class HotelDetails
    {
        public string name { get; set; }
        public int price_s { get; set; }
        public int price_v { get; set; }
    }
    
    public class Hotel
    {
        public string city { get; set; }
        public List<HotelDetails> liste { get; set; }
    }
