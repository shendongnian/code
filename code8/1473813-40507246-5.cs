    using System;
    using System.Web.Mvc;
    
    public class NumericValueBinder : IModelBinder
    {
    	public static void Register()
    	{
    		var binder = new NumericValueBinder();
    		foreach (var type in NumericValueParser.Types)
    		{
    			// Register for both type and nullable type
    			ModelBinders.Binders.Add(type, binder);
    			ModelBinders.Binders.Add(typeof(Nullable<>).MakeGenericType(type), binder);
    		}
    	}
    
    	private NumericValueBinder() { }
    
    	public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    	{
    		var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    		var modelState = new ModelState { Value = valueResult };
    		object actualValue = null;
    		if (!string.IsNullOrWhiteSpace(valueResult.AttemptedValue))
    		{
    			try
    			{
    				var type = bindingContext.ModelType;
    				var underlyingType = Nullable.GetUnderlyingType(type);
    				var valueType = underlyingType ?? type;
    				actualValue = NumericValueParser.Parse(valueResult.AttemptedValue, valueType, valueResult.Culture);
    			}
    			catch (Exception e)
    			{
    				modelState.Errors.Add(e);
    			}
    		}
    		bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
    		return actualValue;
    	}
    }
