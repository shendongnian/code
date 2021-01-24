    public class BookingRooms
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
    }
    public class NightsPerMonth
    {
        public string Area
        {
            get
            {
                return string.Format("{0}/{1}", Month, Year);
            }
        }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Nights { get; set; }
    }
