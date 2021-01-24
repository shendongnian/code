    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
    
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<HttpContext>(p => p.GetService<IHttpContextAccessor>()?.HttpContext);
        services.AddDbContext<MyDbContext>();
    
        var descriptor = new ServiceDescriptor(
            typeof(DbContextOptions),
            DbContextOptionsFactory,
            ServiceLifetime.Scoped);
            
        services.Replace(descriptor);
    
        // ...
    }
    
    private DbContextOptions<MyDbContext> DbContextOptionsFactory(IServiceProvider provider)
    {
        var httpContext = provider.GetService<HttpContext>();
        // here we have the complete HttpContext
        var myHeader = httpContext.Request.Headers["MyHeader"];
        var connectionString = GetConnectionStringFromHeader(myHeader);
    
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        
        return optionsBuilder.Options;
    }
