    public class FooModelBinderProvider : IModelBinderProvider
    {
      private readonly IModelBinderProvider workerProvider;
      public FooModelBinderProvider(IModelBinderProvider workerProvider)
      {
        this.workerProvider = workerProvider;
      }
      public IModelBinder GetBinder(ModelBinderProviderContext context)
      {
        if (context == null)
        {
          throw new ArgumentNullException(nameof(context));
        }
        if (context.Metadata.ModelType == typeof(Foo))
        {
          return new FooModelBinder(this.workerProvider.GetBinder(context));
        }
        return null;
      }
    }
