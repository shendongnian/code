    using System;
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;
    
    namespace Site.Services
    {
        public class DateTimeModelBinder : IModelBinder
        {
            public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
            {
                ValidateBindingContext(bindingContext);
    
                if (!bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName) ||
                    !CanBindType(bindingContext.ModelType))
                {
                    return false;
                }
    
                var modelName = bindingContext.ModelName;
                var attemptedValue = bindingContext.ValueProvider
                    .GetValue(modelName).AttemptedValue;
    
                try
                {
                    bindingContext.Model = DateTime.Parse(attemptedValue);
                }
                catch (FormatException e)
                {
                    bindingContext.ModelState.AddModelError(modelName, e);
                }
    
                return true;
            }
    
            private static void ValidateBindingContext(ModelBindingContext bindingContext)
            {
                if (bindingContext == null)
                {
                    throw new ArgumentNullException("bindingContext");
                }
    
                if (bindingContext.ModelMetadata == null)
                {
                    throw new ArgumentException("ModelMetadata cannot be null", "bindingContext");
                }
            }
    
            public static bool CanBindType(Type modelType)
            {
                return modelType == typeof(DateTime) || modelType == typeof(DateTime?);
            }
        }
    }
