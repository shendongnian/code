     public void CompositionRoot()
     {
          var container = new MyFavouriteContainer();
          container.Register<IServiceA, ServiceAImpl>(); // create my registrations
          ServiceAFactory.SetProvider( () =>
             {
                 // this advanced provider uses the container
                 // this means the implementation, the ServiceAImpl,
                 // can have possible further dependencies that will be
                 // resolved by the container
                 container.Resolve<IServiceA>();
             } );
     }
