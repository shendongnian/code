    public static void Register(HttpConfiguration config)
    {
      IList<IODataRoutingConvention> routingConventions = ODataRoutingConventions.CreateDefault();
      IODataPathHandler pathHandler = new DefaultODataPathHandler();
      routingConventions.Insert(0, new Controllers.DataObjectTypeRoutingConvention());
      config.MapODataServiceRoute(
        routeName: "ODataRoute",
        routePrefix: "odata/dataobjects",
        model: GetEntityModel(),
        pathHandler: pathHandler,
        routingConventions: routingConventions
      );
      config.AddODataQueryFilter();
      config.EnsureInitialized();
    }
    
