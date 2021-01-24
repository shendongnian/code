        public static void Init(IKernel kernel)
        {
            var customResolver = new FuncDependencyResolver
                (
                 (service, contract) =>
                 {
                     if (contract != null)
                         return kernel.GetAll( service, contract );
                     var items = kernel.GetAll( service );
                     var list = items.ToList();
                     return list;
                 }
                 , (factory, service, contract) =>
                 {
                     var binding = kernel
                          .Bind( service )
                          .ToMethod( _ => factory() );
                     if (contract != null)
                         binding.Named( contract );
                 } );
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();
            Locator.CurrentMutable = customResolver;
            Locator.CurrentMutable
                .RegisterLazySingleton
                  (() => new WeinCadViewLocator(kernel)
                  , typeof(IViewLocator));
            var log = SerilogExtensions.DefaultLogger;
            Log.Logger = log;
            SerilogSplatLogger.Register(log);
        }
