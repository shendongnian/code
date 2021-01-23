    var settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All,
        Binder = new JsonSerializationBinder(new DefaultSerializationBinder()),
        Error = (sender, args) => 
        {
            if (args.CurrentObject == args.ErrorContext.OriginalObject
                && args.ErrorContext.Error.InnerExceptionsAndSelf().OfType<JsonSerializationBinderException>().Any()
                && args.ErrorContext.OriginalObject.GetType().GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                args.ErrorContext.Handled = true;
            }
        }
    };
