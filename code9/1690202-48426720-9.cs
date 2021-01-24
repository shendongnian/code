    public class CustomEnumModelBinder : IModelBinder
    {
    	public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
    	{
    		if (bindingContext.ModelType != typeof(Color))
    		{
    			return false;
    		}
    
    		ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    		if (val == null)
    		{
    			return false;
    		}
    
    		string rawValue = val.RawValue as string;
    		if (rawValue == null)
    		{
    			bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Incorrect input value type");
    			return false;
    		}
    
    		//	Your logic for converting string to enum.
    		if (rawValue == "FF0000")
    		{
    			bindingContext.Model = Color.Red;
    			return true;
    		}
    
    		bindingContext.ModelState.AddModelError(bindingContext.ModelName, $"Cannot convert {rawValue} to Color");
    		return false;
    	}
    }
    [Route("getSomething")]
    [HttpGet]
    public string Get([ModelBinder(typeof(CustomEnumModelBinder))] Color color)
    {
        // ...
    }
