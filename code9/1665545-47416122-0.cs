    public class DateTimeModelBinder : IModelBinder
    {
    	private readonly IModelBinder baseBinder = new SimpleTypeModelBinder(typeof(DateTime));
    
    	public Task BindModelAsync(ModelBindingContext bindingContext)
    	{
    		var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    		if (valueProviderResult != ValueProviderResult.None)
    		{
    			bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
    
    			var valueAsString = valueProviderResult.FirstValue;
    
    			//	valueAsString will have a string value of your date, e.g. '31-12-2017'
    			//	Parse it as you need and build DateTime object
    			var dateTime = DateTime.ParseExact(valueAsString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    			bindingContext.Result = ModelBindingResult.Success(dateTime);
    
    			return Task.CompletedTask;
    		}
    
    		return baseBinder.BindModelAsync(bindingContext);
    	}
    }
    [HttpGet]
    public Task<IAsyncResult> GetSomething([FromQuery] [ModelBinder(typeof(DateTimeModelBinder))] date) 
    {
        ...
    }
