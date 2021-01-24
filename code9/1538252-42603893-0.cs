    protected void Application_BeginRequest()
    {
        var obj = new MyObject();
    
        container
            .Resolve<IMyService>(
                new ParameterOverrides
                  {
                      {"obj", obj},
                  }.OnType<MyService>()
            );
    }
