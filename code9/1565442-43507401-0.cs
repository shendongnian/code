    class Event
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public Byte Week { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public virtual ICollection<CalenderWeek> CalenderWeeks{ get; set; }
    }
    
