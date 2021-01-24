    String[] namedServices = ConfigurationManager.AppSettings["MyServices"].Split(','); 
    builder.Register(c => {
               var services = namedServices.Select(s => c.ResolveNamed<IMyService>(s));
               return new MyEngine(services.ToList());
           })
           .As<IMyEngine>();
