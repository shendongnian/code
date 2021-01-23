      public static class UnityConfig
       {
         public static void RegisterComponents()
          {
			var container = new UnityContainer();
            var repositoryAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.FullName == "CManager.Repository, Version=X.X.X.X, Culture=neutral, PublicKeyToken=null"); 
             
			container.RegisterTypes(repositoryAssembly.GetTypes(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);		
		
            container.RegisterType<ApplicationDbContext>(new PerResolveLifetimeManager());
           // ................ register other things is needed
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
         }
      }	
