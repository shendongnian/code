                IUnityContainer container = new UnityContainer();
                container.RegisterType<ILogger>( new InjectionFactory(l => LogManager.GetCurrentClassLogger()));
                container.RegisterType<TestInjection>();
    
                var myTestClass = container.Resolve<TestInjection>(new ResolverOverride[] { new ParameterOverride("logger", container.Resolve<ILogger>()) });
                myTestClass.Process();
