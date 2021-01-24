    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientsJobs>()
            .HasKey(x => new { x.ClientId, x.JobId });
    
        modelBuilder.Entity<ClientsJobs>()
            .HasOne(x => x.Client)
            .WithMany(y => y.Jobs)
            .HasForeignKey(y => y.JobId);
    
        modelBuilder.Entity<ClientsJobs>()
            .HasOne(x => x.Job)
            .WithMany(y => y.Clients)
            .HasForeignKey(y => y.ClientId);
    }
