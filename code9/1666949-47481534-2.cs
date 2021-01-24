    public class ArabicDateTimeBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.Metadata.ModelType == typeof(DateTime))
                return new BinderTypeModelBinder(typeof(ArabicDateTimeBinder));
            return null;
        }
    }
