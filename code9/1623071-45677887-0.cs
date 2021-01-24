    public class RatesResponseObject
    {
        public List<Hotel> hotels { get; set; }
    }
    public class Hotel
    {
        public int hotel_id { get; set; }
        public Dictionary<string, RoomType> room_types { get; set; }
    }
    public class RoomType
    {
        public string url { get; set; }
        public decimal price { get; set; }
        public decimal fees { get; set; }
        public decimal fees_at_checkout { get; set; }
        public decimal taxes { get; set; }
        public decimal taxes_at_checkout { get; set; }
        public decimal final_price { get; set; }
        public int num_rooms { get; set; }
        public string currency { get; set; }
        public List<string> room_amenities { get; set; }
        public List<Discount> discounts { get; set; }
    }
    public class Discount
    {
        public string marketing_text { get; set; }
        public bool is_percent { get; set; }
        public decimal amount { get; set; }
        public decimal price { get; set; }
        public decimal fees { get; set; }
        public decimal fees_at_checkout { get; set; }
        public decimal taxes { get; set; }
        public decimal taxes_at_checkout { get; set; }
        public decimal final_price { get; set; }
    }
