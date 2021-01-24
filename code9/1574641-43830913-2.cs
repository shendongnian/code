    public class MyBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (/* some condition to identify your model */)
                return new BinderTypeModelBinder(typeof(MyBinder));
            return null;
        }
    }
