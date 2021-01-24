    using (ILifetimeScope scope = container.BeginLifetimeScope(childBuilder =>
    {
        childBuilder.RegisterType<AWidget>().As<IWidget>();
        childBuilder.RegisterType<DefaultRule>().As<Rule>();
    }))
    {
        // do things
    }
