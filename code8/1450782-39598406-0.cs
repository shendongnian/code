    public static IUnityContainer Initialise()
        {
          var container = BuildUnityContainer();
    
          DependencyResolver.SetResolver(new UnityDependencyResolver(container));
     
          GlobalConfiguration.Configuration.DependencyResolver = 
                        new Unity.WebApi.UnityDependencyResolver(container);
          return container;
        }
