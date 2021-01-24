    public class FlightInformation
    {
        public FlightInformation()
        {
            Passengers = new List<Customers>();
        }
        public string Flight { get; set; }
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        
        public DateTime Date { get; set; }
    
        public List<Customers> Passengers { get; set; }
    }
