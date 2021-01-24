    public class PartnerRegistry
    {   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RecordId { get; set; }
        public long PatientFileId { get; set; }
        public long PartnerFileId { get; set; }
        [JsonIgnore]  // add this
        public PatientRegistry PatientsRegistry { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
