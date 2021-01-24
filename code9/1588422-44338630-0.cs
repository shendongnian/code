    public class GuidModelBinder : DefaultModelBinder
    {
        public override object BindModel(
                ControllerContext controllerContext,
                ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Guid) ||
                bindingContext.ModelType == typeof(Guid?))
            {
                Guid result;
                var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (valueResult.AttemptedValue == null &&
                        bindingContext.ModelType == typeof(Guid))
                    return Guid.Empty;
                if (valueResult.AttemptedValue == null &&
                        bindingContext.ModelType == typeof(Guid?))
                    return null;
                if (Guid.TryParse(valueResult.AttemptedValue, out result))
                    return result;
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
