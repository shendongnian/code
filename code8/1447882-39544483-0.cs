       var container = new UnityContainer();
       var repositoryAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .First(a => a.FullName == "CManager.Repository, Version=X.X.X.X, Culture=neutral, PublicKeyToken=null");  
       container.RegisterTypes(repositoryAssembly.GetTypes(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);
 
