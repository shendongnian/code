    public class DoubleModelBinder : System.Web.Mvc.DefaultModelBinder {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (result != null && !string.IsNullOrEmpty(result.AttemptedValue)
                && (bindingContext.ModelType == typeof(double) || bindingContext.ModelType == typeof(double?))) {
                double temp;
                if (double.TryParse(result.AttemptedValue, out temp)) return temp;
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
