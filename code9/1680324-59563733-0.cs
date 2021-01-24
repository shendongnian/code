    services.AddDbContext<context1>(options => options.UseSqlServer(Connection1), ServiceLifetime.Scoped);
    services.AddDbContext<context2>(options => options.UseSqlServer(DbConnection2), ServiceLifetime.Scoped);
    // Build an intermediate service provider
	var sp = services.BuildServiceProvider();
	services
		.AddScoped<IGenericRepository<Repository.Models.SubmissionEntry>>(_ => new GenericRepository<SomeSpecificModelThatUsesContext2>(sp.GetService<context2>(), true))
		.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))       
				
