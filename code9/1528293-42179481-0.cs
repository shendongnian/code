        var container = new ServiceContainer();
        container.RegisterControllers();
        container.RegisterControllers(typeof(Areas.Admin.AdminAreaRegistration).Assembly);
        container.Register<INewsService, NewsService>(new PerScopeLifetime());
        container.Register<IRepository<News>, Repository<News>>(new PerRequestLifetime());
        container.Register<ICategoryService, CategoryService>(new PerScopeLifetime());
        container.Register<IRepository<Category>, Repository<Category>>(new PerRequestLifetime());
        container.EnableMvc();
