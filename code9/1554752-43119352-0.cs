    public class DocumentDbRecord
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
    public class HotelMonthlyRecord : DocumentDbRecord
    {
        public HotelCriteria HotelCriteria { get; set; }
        public RoomTypes RoomTypes { get; set; }
    }
