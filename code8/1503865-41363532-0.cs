     public Container Start(HttpConfiguration configuration)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
    
            var conString = ConfigurationManager.ConnectionStrings["DrinksContext"].ConnectionString;
            container.Register(() => new DrinksContext(conString), Lifestyle.Scoped);
    
            container.Register<IUserManager, UserManager>();
            container.Register<IDrinkManager, DrinkManager>(new InjectionConstructor());
            container.Register<IOrderManager, OrderManager>(new InjectionConstructor());
            container.Register<IUnitOfWork, UnitOfWork>();
    
            container.RegisterWebApiControllers(configuration);
    
            container.Verify();
            return container;
        }
