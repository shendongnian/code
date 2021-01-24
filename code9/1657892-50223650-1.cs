    public class StringModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            if (modelName == NullOrWhiteSpace)
                return Task.CompletedTask;
    
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if(valueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;
    
            bindingContext.Result = ModelBindingResult.Success(
                valueProviderResult.FirstValue.TrimAndNullIfWhiteSpace());
    
            return Task.CompletedTask;
        }
    }
