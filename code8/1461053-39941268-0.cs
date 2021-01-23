    public class Guest
    {
            public int GuestId { get; set; }
    
            [Required]
            public string FirstName { get; set; }
    
            //Link to Seat
            public virtual Seat Seat { get; set; }
    }
    
    public class Seat
    {
            public int SeatId { get; set; }
    
            [Required]
            public string SeatNumber { get; set; }
    
            public bool Occupied { get { return (GuestID == null ? true : false); }}
     
            //Link to Guest
            public virtual Guest Guest{ get; set; }
    }
