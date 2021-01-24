    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int Number { get; set; }
        public int Size { get; set; }
        public bool HasBalcony { get; set; }
        public int Beds_1 { get; set; }
        public int Beds_2 { get; set; }
        public double DayPrice { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
