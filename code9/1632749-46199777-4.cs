    public class InterfaceBinderProvider : IModelBinderProvider
    {
        TypeResolverOptions _options;
        public InterfaceBinderProvider(TypeResolverOptions options)
        {
            this._options = options;
        }
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType.GetTypeInfo().IsInterface ? new JsonWhiteListInterfaceBinder(this._options) : null;
        }
    }
