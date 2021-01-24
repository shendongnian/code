        [AutoIncrement]
        public in Id { get; set; }
        public FacilityType Facility { get; set; }
        public SeverityType Severity { get; set; }
        public DateTime Datestamp { get; set; }
        public string Hostname { get; set; }
        public string Content { get; set; }
        public string RemoteIP{ get; set; }
        public DateTime LocalDate { get; set; }
    }
