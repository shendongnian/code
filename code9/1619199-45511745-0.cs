    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = $"<Your new connection string with {variables}>";
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }
