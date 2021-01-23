        var handlerType = typeof(IHandle<>).MakeGenericType(args.GetType());
        var handlers = resolver.Container.Registrations
                           .Where(x => x.RegisteredType.IsGenericType && x.RegisteredType == handlerType)
                           .Select(x => (IHandle)resolver.GetService(x.RegisteredType));
        foreach (IHandle item in handlers)
        {
            item.Handle(args);
        }
