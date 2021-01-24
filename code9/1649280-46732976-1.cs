    public class RouteArrayModelBinder : IModelBinder
    {
        private char separator;
        public RouteArrayModelBinder(char Separator = ',')
        {
            separator = Separator;
        }
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != ValueProviderResult.None)
            {
                var valueAsString = valueProviderResult.FirstValue;
                try
                {
                    var type = bindingContext.ModelType.GetElementType();
                    var values = valueAsString.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(TypeDescriptor.GetConverter(type).ConvertFromString).ToArray();
                    var typedValues = Array.CreateInstance(type, values.Length);
                    values.CopyTo(typedValues, 0);
                    bindingContext.Result = ModelBindingResult.Success(typedValues);
                }
                catch (System.Exception)
                {
                    bindingContext.Result = ModelBindingResult.Failed();
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, $@"Failed to convert ""{valueAsString}"" to ""{bindingContext.ModelType.FullName}""");
                }
            }
        }
    }
