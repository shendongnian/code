    public class PagingEntityBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (typeof(PagingCriteriaBase).IsAssignableFrom(context.Metadata.ModelType))
            {
                return new BinderTypeModelBinder(typeof(PagingModelBinder));
            }
            return null;
        }
    }
