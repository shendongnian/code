    builder.RegisterType<ITextEncoder, Base64UrlTextEncoder>();
    builder.RegisterType<TicketSerializer>()
           .As<IDataSerializer<AuthenticationTicket>>();
    builder.Register(c => new DpapiDataProtectionProvider().Create("ASP.NET Identity"))
           .As<IDataProtector>(); 
