    public class GuidHeaderModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext Context)
        {
            if (Context.Metadata.ModelType == typeof(Guid))
            {
                if (Context.BindingInfo.BindingSource == BindingSource.Header)
                {
                    return new BinderTypeModelBinder(typeof(GuidHeaderModelBinder));
                }
            }
            return null;
        }
    }
