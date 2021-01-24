    public class State
    {
        public int ID { get; set; }
    
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
    
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    
        [Required]
        [ForeignKey("CountryCode")]
        public Country Country { get; set; }
    }
    public class Country
    {
        [Key]
        [StringLength(3)]
        [Column["Code"]]
        public string CountryCode { get; set; }
    
    
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
