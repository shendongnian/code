    public static IAppBuilder CreatePerOwinContext<T>(
    	this IAppBuilder app,
    	Func<IdentityFactoryOptions<T>, IOwinContext, T> createCallback
    )
    where T : class, IDisposable
