        public class Hotel
    {
        public int hotel_id { get; set; }
        public JToken room_types { get; set; }
    }
    public class RatesResponseObject
    {
        public List<Hotel> hotels { get; set; }
    }
    public class RoomDetails
    {
        public int final_price { get; set; }
        public int num_rooms { get; set; }
    }
