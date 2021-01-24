    public class Reservation
    { 
        //Rest of class
        public bool Varovani => DateTo.AddDays(-1).Day <= DateTime.Now.Day;
    }
