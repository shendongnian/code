    public SimpleIntegrationTest()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
        var builder = new DbContextOptionsBuilder<MonsterContext>();
        builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=monsters_db_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
                .UseInternalServiceProvider(serviceProvider);
        _context = new MonsterContext(builder.Options);
        _context.Database.Migrate();
    }
