    class Patient
    {
        public string  Name { get; set; }
        public ICollection<Partner> Partners { get; set; }
    }
    class Partner
    {
        public string Name { get; set; }
        //[JsonIgnore]
        public Patient Patient { get; set; }
    }
