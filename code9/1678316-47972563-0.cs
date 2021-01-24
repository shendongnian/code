    container.Configure(c =>
    {
        c.For<IDataContext>()
            .Use<CarDataContextWrapper>("getting context", ctx=>
            {
                return ctx.GetInstance<CarDataContextWrapper>();
            });
            // Also need to tell SM how to build CarDataContextWrapper
    });
