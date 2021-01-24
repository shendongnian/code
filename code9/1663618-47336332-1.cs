    protected override void OnModelCreating(ModelBuilder modelBuilder){
    modelBuilder.Entity<ApplicationUser>()
        .HasOne(a => a.UserTask)
        .WithOne(b => b.ApplicationUser)
        .HasForeignKey<UserTask>(b => b.UserTaskID);}
