    // HttpContext
    builder.Register(c => new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
       .As<HttpContextBase>().InstancePerLifetimeScope();
    builder.Register(c => c.Resolve<HttpContextBase>().Request)
       .As<HttpRequestBase>().InstancePerLifetimeScope();
    builder.Register(c => c.Resolve<HttpContextBase>().Response)
       .As<HttpResponseBase>().InstancePerLifetimeScope();
    builder.Register(c => c.Resolve<HttpContextBase>().Server)
       .As<HttpServerUtilityBase>().InstancePerLifetimeScope();
    builder.Register(c => c.Resolve<HttpContextBase>().Session)
       .As<HttpSessionStateBase>().InstancePerLifetimeScope();
    
    builder.RegisterType<SessionStateTokenStore>()
       .As<ITokenStore>().InstancePerRequest();
