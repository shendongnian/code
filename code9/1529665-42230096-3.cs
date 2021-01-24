    public class Traveller
    {
        public string surname { get; set; }
        public string quantity { get; set; }
    }
    
    public class TravellerInformation
    {
        public object passenger { get; set; }
        public Traveller traveller { get; set; }
    }
    
    public class PassengerData
    {
        public TravellerInformation travellerInformation { get; set; }
    }
    
    public class TravellerInfo
    {
        public PassengerData passengerData { get; set; }
    }
