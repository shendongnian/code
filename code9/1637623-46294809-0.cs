    using(var scope = container.CreateChildContainer())
    {
      var service = scope.Resolve<IService>();
    
      using(var nestedScope = scope.CreateChildContainer())
      {
        var anotherService = nestedScope.Resolve<IOther>();
      }
    }
