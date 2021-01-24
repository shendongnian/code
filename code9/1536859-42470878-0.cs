	private static void RegisterServicdes(IKernel kernel)
	{
		kernel.Bind<ISiteContext>().To<SiteContext>().InRequestScope();
		// register other services...
	}
