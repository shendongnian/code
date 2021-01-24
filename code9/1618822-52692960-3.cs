    builder.Register(c =>
    {
        //Again, we must store a new instance of a component context for later use.
        var context = c.Resolve<IComponentContext>();
        var profiles = c.Resolve<IEnumerable<Profile>>();
        return new MapperConfiguration(x =>
        {
            foreach (var profile in profiles)
            {
                x.AddProfile(profile);
            }
            //Registering the service resolver method here.
            x.ConstructServicesUsing(context.Resolve);
        });
    })
    .SingleInstance()
    .AsSelf();
