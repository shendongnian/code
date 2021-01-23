    public class SenderModel
    {
        [Key]
        public int SenderId { get; set; }
    
        [Display(Name = "Sender Name")]
        public string SenderName { get; set; }
        [Display(Name = "Sender Type")]
        public SenderType SenderType { get; set; } // SenderType should be of type enum SenderType
        [Display(Name = "Sender Purpose")]
        public string SenderPurpose { get; set;}
    
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
