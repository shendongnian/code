    container.Register(
       Classes.FromAssembly(myDynamicAssembly)
          .IncludeNonPublicTypes()
          .BasedOn<ApiController>()
          .LifestylePerWebRequest());
