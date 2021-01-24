    public class ApplicationUser : IdentityUser<int>
    {
        public string Id {get; set;}
        // OTHER PROPERTIES ABOVE
        public virtual ICollection<UserToUser> Following { get; set; }
        public virtual ICollection<UserToUser> Followers { get; set; }
    }
    
    public class UserToUser 
    {
        public ApplicationUser User { get; set;}
        public string UserId { get; set;}
        public ApplicationUser Follower { get; set;}
        public string FollowerId {get; set;}
    }
    
    // Context File
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<UserToUser>()
            .HasKey(k => new { k.UserId, k.FollowerId });
    
        modelBuilder.Entity<UserToUser>()
            .HasOne(l => l.User)
            .WithMany(a => a.Followers)
            .HasForeignKey(l => l.UserId);
    
        modelBuilder.Entity<UserToUser>()
            .HasOne(l => l.Follower)
            .WithMany(a => a.Following)
            .HasForeignKey(l => l.FollowerId);
    }
