    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    	// ...
    	optionsBuilder.UseEF6CompatibleValueGeneration();
    }
