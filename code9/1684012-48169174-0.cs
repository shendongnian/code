    class ApplicationUser
    {
        public int Id {get; set;}
        // every ApplicationUser has zero or more Steps:
        public virtual ICollection<Step> Steps {get; set;}
        public string Name {get; set;}
        ...
    }
    class Step
    {
        public int Id {get; set;}
        // every Step is performed by zero or more ApplicationUsers:
        public virtual ICollection<ApplicationUser> ApplicationUsers {get; set;}
        public string Name {get; set;}
        ...
    }
    public MyDbContext : DbContext
    {
        public DbSet<ApplicationUser ApplictionUsers {get; set;}
        public DbSet<Step> Steps {get; set;}
    }
