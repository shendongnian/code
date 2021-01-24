    public class DecimalModelBinder: System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
            ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            if (valueResult.AttemptedValue != string.Empty)
            {
                try
                {
                    string attemptedVal = valueResult.AttemptedValue?.Replace(",", ".").Replace("$", "");
                    actualValue = Convert.ToDecimal(attemptedVal, new CultureInfo("en-US"));
                }
                catch (FormatException e)
                {
                    modelState.Errors.Add(e);
                }
            }
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
