    public class GuidModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            Guid guidValue;
            if (value == null || !Guid.TryParse(value.AttemptedValue, out guidValue))
            {
                bindingContext.ModelState.AddModelError("guid", "The value is invalid");
                return Guid.Empty;
            }
            return guidValue;
        }
    }
