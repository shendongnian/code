    class AuthorityUser
    {
        // Primary Key (reconsider: Id)
        public int UserID { get; set; } 
        // an AuthorityUser belongs to zero or more Authorities (many-to-many)
        public virtual ICollection<Authority> Authorities { get; set; }
        ... // other properties
    }
    class Authority
    {
        // primary key (reconsider: Id)
        public int AID {get; set;}
        // an Authority has zero or more AuthorityUsers (many-to-many)  
        public virtual ICollection<AuthorityUser> AuthorityUsers { get; set; }
        ... // other users
    }
    class MyDbContext : DbContext
    {
        public DbSet<AuthorityUser> AuthorityUsers {get; set;}
        public DbSet<Authority> Authorities {get; set;}
    }
