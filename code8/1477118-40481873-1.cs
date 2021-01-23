        // this is foreign key property
        public int PrivilegeLookupId { get; set; }
        // this is navigation property with related foreign key property
        [ForeignKey("PrivilegeLookupId")]  
        public PrivilegeLookup privilegeLookup { get; set; }
