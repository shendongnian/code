    builder
        .RegisterType<CommandAHandler>()
        .WithParameters(
            new[] {
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(DbContext),
                    (pi, ctx) => ctx.ResolveNamed<DbContext>("Write")
                )
            });
    builder
        .RegisterType<CommandBHandler>()
        .WithParameters(
            new[] {
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(DbContext),
                    (pi, ctx) => ctx.ResolveNamed<DbContext>("Read")
                )
            });
