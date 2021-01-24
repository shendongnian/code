    var pageFactory = new NamedInstanceFactory<Page>(Container);
    Container.RegisterSingleton<INamedInstanceFactory<Page>>(pageFactory);
	
    pageFactory.RegisterType(typeof(StartPage), Lifestyle.Singleton);
    pageFactory.RegisterType(typeof(UserDetailsPage), Lifestyle.Transient);
    pageFactory.RegisterType(typeof(SomeOtherPage), Lifestyle.Transient);
