    public class FloatModelBinder : IModelBinder
    {
      public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
      {
        ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        ModelState modelState = new ModelState { Value = valueResult };
        object actualValue = null;
        try
        {
          if (bindingContext.ModelMetadata.EditFormatString.StartsWith("{0:c", StringComparison.InvariantCultureIgnoreCase))
          {
            actualValue = float.Parse(valueResult.AttemptedValue, NumberStyles.Currency);
          }
          else
          {
            actualValue = float.Parse(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
          }
        }
        catch (FormatException e)
        {
          modelState.Errors.Add(e);
        }
        bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
        return actualValue;
      }
    }
