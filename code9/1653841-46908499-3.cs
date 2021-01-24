    public class SomeDataEntity
    {
        public int PrimaryKey { get; set; }
    
        [Required]
        public int? ForeignKey { get; set; }
    
        public bool C_IS_EMPLOYEED { get; set; }
    
        [RequiredIf("C_IS_EMPLOYEED")]
        public string C_JOB_TITLE { get; set; }
    }
