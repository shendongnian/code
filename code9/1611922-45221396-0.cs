    public virtual IDbSet<Parent> Parents { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Child1>().ToTable("Child1");
         modelBuilder.Entity<Child2>().ToTable("Child2");
    }
