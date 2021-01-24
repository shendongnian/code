    //
    // Summary:
    //     Registers the given context as a service in the 
    //     Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //     You use this method when using dependency injection in your application, such
    //     as with ASP.NET. For more information on setting up dependency injection, see
    //     http://go.microsoft.com/fwlink/?LinkId=526890.
    //     This overload has an optionsAction that provides the applications 
    //     System.IServiceProvider.
    //     This is useful if you want to setup Entity Framework to resolve its internal
    //     services from the primary application service provider. By default, we recommend
    //     using the other overload, which allows Entity Framework to create and maintain
    //     its own System.IServiceProvider for internal Entity Framework services.
    //
    // Parameters:
    //   serviceCollection:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
    //     to.
    //
    //   optionsAction:
    //     An optional action to configure the Microsoft.EntityFrameworkCore.DbContextOptions
    //     for the context. This provides an alternative to performing configuration of
    //     the context by overriding the Microsoft.EntityFrameworkCore.DbContext
    //     .OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)
    //     
    //     method in your derived context.
    //     If an action is supplied here, the 
    //     Microsoft.EntityFrameworkCore.DbContext
    //     .OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)
    //     method will still be run if it has been overridden on the 
    //     derived context. Microsoft.EntityFrameworkCore.DbContext
    //     .OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)
    //     configuration will be applied in addition to configuration performed here.
    //     In order for the options to be passed into your context, you need 
    //     to expose a constructor on your context that takes 
    //     Microsoft.EntityFrameworkCore.DbContextOptions`1
    //     and passes it to the base constructor of 
    //     Microsoft.EntityFrameworkCore.DbContext.
    //
    //   contextLifetime:
    //     The lifetime with which to register the DbContext 
    //   service in the container.
    //
    //   optionsLifetime:
    //     The lifetime with which to register the DbContextOptions
    //     service in the container.
    //
    // Type parameters:
    //   TContext:
    //     The type of context to be registered.
    //
    // Returns:
    //     The same service collection so that multiple calls can be chained.
    public static IServiceCollection AddDbContext<TContext>(
        [NotNullAttribute] this IServiceCollection serviceCollection, 
        [CanBeNullAttribute] Action<IServiceProvider, DbContextOptionsBuilder> optionsAction, 
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped, 
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped
    ) where TContext : DbContext;
