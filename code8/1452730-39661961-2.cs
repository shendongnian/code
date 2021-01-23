    public class Hotel
    {
        public int ID { get; set; }
        public List<Accomodation> Accomodations { get; set; }
        public bool SelectedInPreviousLeg {  get set; }
    }
    public class Accomodation
    {
        public int HotelID { get; set; }
    }
