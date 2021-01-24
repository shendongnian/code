    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        if (context.BindingInfo.BindingSource != null &&
                context.BindingInfo.BindingSource.CanAcceptDataFrom(BindingSource.Header))
        {
            // We only support strings and collections of strings. Some cases can fail
            // at runtime due to collections we can't modify.
            if (context.Metadata.ModelType == typeof(string) ||
                context.Metadata.ElementType == typeof(string))
            {
                return new HeaderModelBinder();
            }
        }
        return null;
    }
