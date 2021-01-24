    public class RouteArrayModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Metadata.ModelType.IsArray)
            {
                return new RouteArrayModelBinder();
            }
            return null;
        }
    }
