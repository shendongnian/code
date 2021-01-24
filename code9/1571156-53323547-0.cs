    using System;
    using System.Globalization;
    using System.Web.Mvc;
    public class ValueTypeModelBinder<T> : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var modelState = new ModelState { Value = valueResult };
            var result = default(T);
            try
            {
                var srcValue = valueResult.AttemptedValue;
                var targetType = typeof(T);
                //Hp --> Logic: Check whether target type is nullable (or) not? 
                //If Yes, Take underlying type for value conversion.
                if (targetType.IsGenericType &&
                    targetType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    targetType = Nullable.GetUnderlyingType(targetType);
                }
                if (targetType.IsValueType && (!string.IsNullOrWhiteSpace(srcValue)))
                {
                    result = (T)Convert.ChangeType(srcValue, targetType, CultureInfo.CurrentUICulture);
                }
            }
            catch (Exception ex)
            {
                modelState.Errors.Add(ex);
            }
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return result;
        }
    }
