    public class Guest
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
    
        public IList<Seat> Seats { get; set; }
    }
