    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // ...
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
    }
