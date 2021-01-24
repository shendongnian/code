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
    
            DateTime dateTime;
            // I'm unsure whether this will handle the arabic digits correctly or not, so I have also included the suggested approach by g.Irani as a fallback
            if (DateTime.TryParse(value, new CultureInfo("ar"), DateTimeStyles.None, out dateTime))
            {
                bindingContext.Result = ModelResult.Success(dateTime);
                return Task.CompletedTask;
            }
            // As per g.Irani's suggestion:
            value = value.Replace('\u06f0', '0')
                    .Replace('\u06f1', '1')
                    .Replace('\u06f2', '2')
                    .Replace('\u06f3', '3')
                    .Replace('\u06f4', '4')
                    .Replace('\u06f5', '5')
                    .Replace('\u06f6', '6')
                    .Replace('\u06f7', '7')
                    .Replace('\u06f8', '8')
                    .Replace('\u06f9', '9');
            if (DateTime.TryParse(value, out dateTime))
            {
                bindingContext.Result = ModelResult.Success(dateTime);
                return Task.CompletedTask;
            }
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "DateTime was not in the expected format");
            return Task.CompletedTask;
        }
    }
