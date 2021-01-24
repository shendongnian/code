    var builder = new ContainerBuilder();                
            builder
                .RegisterType<MyContext>()
                .As<DbContext>()
                .WithMetadata("EFContext", "My");
            builder
                .RegisterType<MyRepository>()
                .AsImplementedInterfaces();
            builder
                .RegisterType<MyOtherContext>()
                .As<DbContext>()
                .WithMetadata("EFContext", "Other");
            builder
                .RegisterType<MyOtherRepository>()
                .AsImplementedInterfaces();
