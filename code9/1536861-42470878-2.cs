	private static void RegisterServicdes(IKernel kernel)
	{
		kernel.Bind<ISiteContext>().To<SiteContext>().InRequestScope();
		kernel.Bind<IDbContextFactory>().To<DbContextFactory>().InRequestScope();
		// register other services...
	}
