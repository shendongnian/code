    var settings = new JsonSerializerSettings
    {
        SerializationBinder = new JsonSerializationBinder(new DefaultSerializationBinder()),
        TypeNameHandling = TypeNameHandling.All, // Or Auto or Objects as appropriate
        Error = (sender, args) =>
        {
            if (args.CurrentObject == args.ErrorContext.OriginalObject
                && args.ErrorContext.Error.InnerExceptionsAndSelf().OfType<JsonSerializationBinderException>().Any()
                && args.ErrorContext.OriginalObject.GetType().GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                args.ErrorContext.Handled = true;
            }
        },
    };
