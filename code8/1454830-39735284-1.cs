    // Do not validate when adding from a group
    container.RegisterConditional(typeof(IEntityWriter),
        typeof(Decorators.EntityWriterValidationDecorator),
        context => context.Consumer.ServiceType != typeof(IGroupWriter)
            && context.Consumer.ImplementationType != context.ImplementationType);
    // Do not use the decorator in the Document Writer (We need to find the 'None' entity
    container.RegisterConditional(typeof(IEntityReader),
        typeof(Service.Decorators.EntityReaderExcludeDefaultEntitiesDecorator),
        context => context.Consumer.ServiceType != typeof(IDocumentWriter)
            && context.Consumer.ImplementationType != context.ImplementationType);
