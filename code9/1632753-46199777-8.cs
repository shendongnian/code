    public class InterfaceBinderProvider : IModelBinderProvider
    {
        TypeResolverOptions _options;
        
        public InterfaceBinderProvider(TypeResolverOptions options)
        {
            this._options = options;
        }
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (!context.Metadata.IsCollectionType &&
                (context.Metadata.ModelType.GetTypeInfo().IsInterface ||
                 context.Metadata.ModelType.GetTypeInfo().IsAbstract) &&
                (context.BindingInfo.BindingSource == null ||
                !context.BindingInfo.BindingSource
                .CanAcceptDataFrom(BindingSource.Services)))
            {
                return new InterfaceBinder(this._options, context);
            }
            return null;
        }
    }
