    public class ArabicDateTimeBinder: IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.BinderModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
    
            if (valueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;
    
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
    
            var value = valueProviderResult.FirstValue;
    
            if (string.IsNullOrEmpty(value))
                return Task.CompletedTask;
    
            DateTime dateTime = new DateTime();
            if (DateTime.TryParse(value, new CultureInfo("ar"), DateTimeStyles.None, out dateTime))
            {
                bindingContext.Result = ModelResult.Success(dateTime);
                return Task.CompletedTask;
            }
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "DateTime was not in the expected format");
            return Task.CompletedTask;
        }
    }
