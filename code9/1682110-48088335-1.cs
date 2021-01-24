    builder.RegisterType<ActivityOne>()
           .As<IActivity>()
           .WithMetadata("activity", ActivityType.One);
    builder.RegisterType<ActivityTwo>()
           .As<IActivity>()
           .WithMetadata("activity", ActivityType.Two);
    builder.RegisterType<ActivityThree>()
           .As<IActivity>()
           .WithMetadata("activity", ActivityType.Three);
