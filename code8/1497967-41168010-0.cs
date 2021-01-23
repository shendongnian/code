    container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter("."))
                    .BasedOn(typeof(IScheduleJob)).
                    WithServiceAllInterfaces()
            );
