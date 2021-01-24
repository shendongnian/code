	 [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
	 [assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]
	 namespace <YOURNAMESPACE>
	 {
		 public static class NinjectWebCommon
		 {
			 private static readonly Bootstrapper bootstrapper = new Bootstrapper();
			 public static void Start()
			 {
				 DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
				 DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
				 bootstrapper.Initialize(CreateKernel);
			 }
			 public static void Stop()
			 {
				 bootstrapper.ShutDown();
			 }
			 private static IKernel CreateKernel()
			 {
				 var kernel = new StandardKernel();
				 kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				 kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
				 RegisterServices(kernel);
				 return kernel;
			 }
			 private static void RegisterServices(IKernel kernel)
			 {
			   //kernel.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));
			 }
		 }
	 }
