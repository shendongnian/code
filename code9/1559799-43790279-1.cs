    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int aspnet_id{ get; set; }
        public DateTime? LastLogin { get; set; }
    }
