    private void Register()
    {
        var builder = new ContainerBuilder();
        builder.Register(c => new WebContentProvider("http://the.1st.url"))
            .Keyed<IContentProvider>(typeof(FirstContentUser));
        builder.Register(c => new WebContentProvider("http://the.2nd.url"))
            .Keyed<IContentProvider>(typeof(SecondContentUser));
        builder.RegisterType<FirstContentUser>()
                .As<IContentUser>()
                .WithParameter(
                CreateResolvedParameter<IContentProvider, FirstContentUser>());
        builder.RegisterType<SecondContentUser>()
            .As<IContentUser>()
                .WithParameter(
                CreateResolvedParameter<IContentProvider, SecondContentUser>());
        container = builder.Build();
    }
    private static ResolvedParameter CreateResolvedParameter<ParamType, KeyType>()
    {
        return new ResolvedParameter(
            (pi, ctx) => pi.ParameterType == typeof(ParamType),
            (pi, ctx) => ctx.ResolveKeyed<ParamType>(typeof(KeyType)));
    }
