    public static void RegisterTypes(IUnityContainer container)
    {
        var repository = container.Resolve<ILocalDatabaseService>();
        var referentielLocalDatabase = repository.GetRsh();
        // This says "if you ever need need a string called 'xxxx', get that one."
		container.RegisterInstance<string>("serveur", referentielLocalDatabase.Serveur);
		container.RegisterInstance<string>("catalog", referentielLocalDatabase.Base);
		container.RegisterInstance<string>("user", referentielLocalDatabase.User);
		container.RegisterInstance<string>("pass", referentielLocalDatabase.Password);
        // Here it says "Find a constructor that needs 4 strings, and use
        // these registered string.
        container.RegisterType<Repositories.ITypeHeureRepository, Repositories.TypeHeureRepository>(
			new ParameterResolve<string>("serveur"),
			new ParameterResolve<string>("catalog"),
			new ParameterResolve<string>("user"),
			new ParameterResolve<string>("pass"));
        container.RegisterType<Repositories.ITypeTacheRepository, Repositories.TypeTacheRepository>(
			new ParameterResolve<string>("serveur"),
			new ParameterResolve<string>("catalog"),
			new ParameterResolve<string>("user"),
			new ParameterResolve<string>("pass"));
        container.RegisterType<Repositories.IUtilisateurOkapiRepository, Repositories.UtilisateurOkapiRepository>(
			new ParameterResolve<string>("serveur"),
			new ParameterResolve<string>("catalog"),
			new ParameterResolve<string>("user"),
			new ParameterResolve<string>("pass"));
        container.RegisterType<Repositories.ISocieteOkapiRepository, Repositories.SocieteOkapiRepository>(
			new ParameterResolve<string>("serveur"),
			new ParameterResolve<string>("catalog"),
			new ParameterResolve<string>("user"),
			new ParameterResolve<string>("pass"));
        container.RegisterType<Repositories.IProfilOkapiRepository, Repositories.ProfilOkapiRepository>(
			new ParameterResolve<string>("serveur"),
			new ParameterResolve<string>("catalog"),
			new ParameterResolve<string>("user"),
			new ParameterResolve<string>("pass"));
        container.RegisterType<Repositories.ICentreOkapiRepository, Repositories.CentreOkapiRepository>(
			new ParameterResolve<string>("serveur"),
			new ParameterResolve<string>("catalog"),
			new ParameterResolve<string>("user"),
			new ParameterResolve<string>("pass"));
        container.RegisterType<Repositories.IBuildVersionOkapiRepository, Repositories.BuildVersionOkapiRepository>(
			new ParameterResolve<string>("serveur"),
			new ParameterResolve<string>("catalog"),
			new ParameterResolve<string>("user"),
			new ParameterResolve<string>("pass"));
		
        // Here it says "For IMediation, use the Mediation class".
        // The constructor you've shown us will required the other interfaces and
        // the container will be like "I know how to create a class of all of
        // these interfaces. I'll do that!"
        container.RegisterType<IMediation, WebService.Mediation>();
    }
