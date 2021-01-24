    builder.RegisterType<Base64UrlTextEncoder>().As<ITextEncoder>().InstancePerLifetimeScope();
    builder.RegisterType<TicketSerializer>()
         .As<IDataSerializer<AuthenticationTicket>>()
         .InstancePerLifetimeScope();
    builder.Register(c =>
        new MachineKeyDataProtectionProvider().Create(
        typeof(OAuthAuthorizationServerMiddleware).Namespace,
        "Access_Token",
        "v1"))
        .As<IDataProtector>()
        .InstancePerLifetimeScope();
    builder.RegisterType<SecureDataFormat<AuthenticationTicket>>()
           .As<ISecureDataFormat<AuthenticationTicket>>()
           .InstancePerLifetimeScope();
