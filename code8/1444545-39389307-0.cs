    public class LocationInformation
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public override string ToString()
        {
            return String.Format("Guy with ID : ({0}), was near {1} at {2}", ID, Location, Date);
        }
    }
