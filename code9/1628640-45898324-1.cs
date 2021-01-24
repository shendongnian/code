    [NotMapped]
    class NotRequired : BaseEntity
    {
        // NOT REQUIRED // START
        public Guid? CreatedByUserId { get; set; }
        public string CreatedComputerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedIP { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public string ModifiedComputerName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedIP { get; set; }
       // NOT REQUIRED // END
    }
