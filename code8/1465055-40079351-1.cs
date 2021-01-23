    public class RedemptionCode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key,ForeignKey("UserProfile")]
        public int Id { get; set; }
               
        public int? UserProfileId { get; set; }
    
        [ForeignKey("UserProfile")]
        public virtual UserProfile UserProfile { get; set; }
    
        [Required]
        public string Code { get; set; }
    }
