    public class Seat
    {
        public int ID { get; set; }
        [Required]
        public string SeatNumber{ get; set; }
    
        public IList<Guest> Guests { get; set; }
    }
