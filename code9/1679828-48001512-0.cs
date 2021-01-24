    public class PersianCharsModelBinder : IModelBinder
    {
        private readonly IModelBinder _simpleTypeModelBinder;
        public PersianCharsModelBinder(IModelBinder simpleTypeModelBinder)
        {
            _simpleTypeModelBinder = simpleTypeModelBinder;
        }
    
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == ValueProviderResult.None) return _simpleTypeModelBinder.BindModelAsync(bindingContext);
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
            var valueAsString = valueProviderResult.FirstValue;
            if (string.IsNullOrWhiteSpace(valueAsString)) return _simpleTypeModelBinder.BindModelAsync(bindingContext);
            var model = valueAsString.ToEnglishNumber().RemoveArabicChars();
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
    
    public class PersianCharsBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.Metadata.IsComplexType) return null;
            var simpleTypeModelBinder = new SimpleTypeModelBinder(context.Metadata.ModelType);
            if (context.Metadata.ModelType == typeof(string)) return new PersianCharsModelBinder(simpleTypeModelBinder);
            return simpleTypeModelBinder;
        }
    }
