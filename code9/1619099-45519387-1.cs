            kernel.Bind(x =>
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .InheritedFrom<IAuditable>()
                    .BindDefaultInterfaces()
                    .Configure(c => c.Intercept().With<IAuditInterceptor>()));
            kernel.Bind(x =>
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .InheritedFrom<IProcessor>()
                    .Where(t => !typeof(IAuditable).IsAssignableFrom(t))
                    .BindDefaultInterfaces());
