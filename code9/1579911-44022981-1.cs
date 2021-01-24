    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    services.AddDbContext<MyDbContext>();
    var descriptor = new ServiceDescriptor(typeof(DbContextOptions),
        p => {
            var httpContextAccessor = p.GetService<IHttpContextAccessor>();
            var httpContext = httpContextAccessor.HttpContext;
            // here we have the complete HttpContext
            var myHeader = httpContext.Request.Headers["MyHeader"];
            var connectionString = GetMyConnectionStringFromHeaderOrWhatever(myHeader);
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            // add any other options here using methods on optionsBuilder
            return optionsBuilder.Options;
        },
        ServiceLifetime.Scoped);
        
    services.Replace(descriptor);
