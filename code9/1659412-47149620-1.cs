    public class StringArrayModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null || string.IsNullOrEmpty(value.AttemptedValue))
            {
                return null;
            }
    
            return value
                .AttemptedValue
                // use .Split() here if you want to split by particular character(s)
                .ToArray();
        }
    }
