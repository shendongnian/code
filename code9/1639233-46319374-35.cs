    builder.RegisterType<TokenHttpHandler>().AsSelf();
                builder.RegisterType<ExtendedHttpClient>().As<HttpClient>();
    
    builder.RegisterType<TokenCache>()
                    .As<ITokenCache>()
                    .WithParameter("scope", "YOUR_SCOPES")
                    .OnActivating(e => e.Instance.TokenClient = e.Context.Resolve<TokenClient>())
                    .SingleInstance();
    
    builder.Register(context =>
                    {
                        var address = "YOUR_AUTHORITY";
    
                        return new TokenClient(address, "ClientID", "Secret");
                    })
                    .AsSelf();
