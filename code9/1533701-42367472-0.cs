    public class Personal
        {
            public string UserName { get; set; }
            
            public string ApplicationUserID { get; set; }
    
            [ForeignKey("ApplicationUserID")]
            public virtual ApplicationUser ApplicationUser { get; set; }
        }
    public class ApplicationUser : IdentityUser
        {
            [Key]
            public string ApplicationUserID { get; set; }
            public virtual Personal PersonalU { get; set; }
        }
    protected override void OnModelCreating(DbModelBuilder builder)
            {
                builder.Entity<Personal>()
                    .HasKey(m => m.ApplicationUserID);
                    
                    builder.Entity<ApplicationUser>()
                    .HasRequired(current => current.PersonalU)
                    .WithOptional(user => user.ApplicationUser)
                    .WillCascadeOnDelete(true);
    }
