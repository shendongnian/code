    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Project>().HasKey(m => m.ProjectPath);
        builder.Entity<Target>().HasKey(m => m.Guid);
        base.OnModelCreating(builder);
    } 
