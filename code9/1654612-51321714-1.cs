    services.AddDbContext<YourDataContext>(options =>
    {
        options.UseSqlServer(YourConnectionString);
        options.ReplaceService<ISqlServerUpdateSqlGenerator, SqlServerUpdateSqlGeneratorInsertIdentity>();
    });
