    public class MyViewModelBinderProvider : IModelBinderProvider
    {
    	public IModelBinder GetBinder(ModelBinderProviderContext context)
    	{
    		if (context.Metadata.ModelType == typeof(MyCustomModel))
    			return new MyViewModelBinder();
    
    		return null;
    	}
    }
