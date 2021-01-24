    public class ModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
    
            if (context.Metadata.ModelType == typeof(string))
                return new BinderTypeModelBinder(typeof(StringModelBinder));
    
            return null;
        }
    }
