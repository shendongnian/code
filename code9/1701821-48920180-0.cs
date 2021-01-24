    public class CustomModelBinderProvider<TModel> : ModelBinderProvider
    {
    	private readonly IModelBinder binder;
    
    	public CustomModelBinderProvider(IModelBinder binder)
    	{
    		this.binder = binder;
    	}
    
    	public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
    	{
    		return modelType == typeof(TModel) ? binder : null;
    	}
    }
