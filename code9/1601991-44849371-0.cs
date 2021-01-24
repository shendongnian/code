    public class Booking
    {
        public int Id { get; set; }
        public int IDRestaurant{ get; set; }
        [CustomPlace("IDRestaurant", "Date", ErrorMessage = "the restaurant is full")]
        public int Nbpeople { get; set; }
        [CustomDateValidator]
        public DateTime Date { get; set; }
    }
