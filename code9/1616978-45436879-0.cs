    public class ApplicationUser : IdentityUser
    {       
        public virtual ICollection<Character> Characters { get; set; }
    }
    public class Character
    {
        public Guid Id { get; set; }
        public string ParentId { get; set; }
        public string UserId { get; set; }
    
        [Required]
        [ForeignKey("ParentId")]
        public virtual ApplicationUser Parent { get; set; }
    
        [Required]
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    
        // other properties
    }
