      public IEnumerable<IComponentRegistration> RegistrationsFor(
        Service service,
        Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
      {
        var swt = service as IServiceWithType;
        if(swt == null || !typeof(BaseClass).IsAssignableFrom(swt.ServiceType))
        {
          // It's not a request for the BaseClass type, so skip it.
          return Enumerable.Empty<IComponentRegistration>();
        }        
        var registration = new ComponentRegistration(
          Guid.NewGuid(),
          new DelegateActivator(swt.ServiceType, (c, p) =>
            {
              var myService = c.Resolve<IService>();
              ...
            }
            ...
      }
      ...
    }
