    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       Assembly assemblyWithConfigurations = GetType().Assembly; //get whatever assembly you want
       modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
    }
