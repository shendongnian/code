    public class MyViewModelBinder : IModelBinder
    {
    	public Task BindModelAsync(ModelBindingContext bindingContext)
    	{
    		var jsonString = bindingContext.ActionContext.HttpContext.Request.Query["query"];
    		MyCustomModel result = JsonConvert.DeserializeObject<MyCustomModel>(jsonString);
    
    		bindingContext.Result = ModelBindingResult.Success(result);
    		return Task.CompletedTask;
    	}
    }
