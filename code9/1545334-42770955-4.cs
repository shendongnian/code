    //
    // Summary:
    //     Registers an action used to configure a particular type of options. ///
    //
    // Parameters:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   configureOptions:
    //     The action used to configure the options.
    //
    // Type parameters:
    //   TOptions:
    //     The options type to be configured.
    //
    // Returns:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
    //     calls can be chained.
    public static IServiceCollection Configure<TOptions>(this IServiceCollection services,
         Action<TOptions> configureOptions) where TOptions : class;
