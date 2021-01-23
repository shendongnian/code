    public class ApplicationUser : IdentityUser {
        
    } 
    public class Server : ApplicationUser {
    }
    public class HumanUser : ApplicationUser {
        
        [Required]
        public virtual GlobalInventory GlobalInventory { get; set; }
    }
    public class GlobalInventory {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public virtual HumanUser User { get; set; }
    }
