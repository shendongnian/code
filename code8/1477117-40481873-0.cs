        // this is foreign key property with related "privilegeLookup" navigation property. Database column name will be PrivilegeLookupId
        [ForeignKey("privilegeLookup"), Column(Order = 1)]       
        public int PrivilegeLookupId { get; set; }
        // this is related navigation property
        public PrivilegeLookup privilegeLookup { get; set; }
