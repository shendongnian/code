    public class ApplicationUser : IdentityUser {
        [Required]
        public virtual GlobalInventory GlobalInventory { get; set; }
    } 
    public class HumanUser : ApplicationUser {
        
        [Required]
        public virtual GlobalInventory GlobalInventory { get; set; }
    }
    public class GlobalInventory {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
    }
