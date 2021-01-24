    class Venue
    {
        public string VenueKey { get; set; }
    
        public bool IsShortBook { get; set; }
    
        public bool IsSaturday { get; set; }
    
        public Slot[] Slots { get; set; }
    }
    
    class Slot
    {
        public string TS { get; set; }
    
        public string @String { get; set; }
    
        public bool ISAvailable { get; set; }
    }
