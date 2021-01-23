    public class JsonModelBinder : IModelBinder
    {
        private IJsonAttribute _attribute;
        private Type _targetType;
        public JsonModelBinder(Type type, IJsonAttribute attribute)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            _attribute = attribute as IJsonAttribute;
            _targetType = type;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));
            // Check the value sent in
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
                // Attempt to convert the input value
                var valueAsString = valueProviderResult.FirstValue;
                bool success;
                var result = _attribute.TryConvert(valueAsString, _targetType, out success);
                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }
    }
