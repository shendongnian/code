    public class Chamber
    {
        public int ChamberNumber { get; set; }
        public int MaxGuests { get; set; } 
        public bool Isbooked { get; set; }
        public static List<Person> persons = new List<Person>();
    
        public Chamber(int chambernumber, int max, Boolean booked)
        {
            ChamberNumber = chambernumber;
            MaxGuests = max;
            IsBooked = booked;
        }
    }
