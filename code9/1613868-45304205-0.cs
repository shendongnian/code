    container.Register(
        Classes.FromThisAssembly()
            .InNamespace("YourNamespace")
            .WithService.DefaultInterfaces()
    );
