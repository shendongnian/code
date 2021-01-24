    builder.RegisterType<MyService>()
           .Named<MyService>("Service1")
           .OnActivating(e =>
           {
               MyService s = new MyService("Service1", 
                                           "param1-23",
                                           e.Context.Resolve<IRepository>())
               e.ReplaceInstance();
           });
