    public sealed class ValidateActionParametersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor;
            if (descriptor != null)
            {
                var modelState = context.Controller.ViewData.ModelState;
                foreach (var parameterDescriptor in descriptor.GetParameters())
                {
                    EvaluateValidationAttributes(
                        suppliedValue: context.ActionParameters[parameterDescriptor.ParameterName],
                        modelState: modelState,
                        parameterDescriptor: parameterDescriptor
                    );
                }
            }
   
            base.OnActionExecuting(context);
        }
   
        static private void EvaluateValidationAttributes(ParameterDescriptor parameterDescriptor, object suppliedValue, ModelStateDictionary modelState)
        {
            var parameterName = parameterDescriptor.ParameterName;
            parameterDescriptor
                .GetCustomAttributes(inherit: true)
                .OfType<ValidationAttribute>()
                .Where(x => !x.IsValid(suppliedValue))
                .ForEach(x => modelState.AddModelError(parameterName, x.FormatErrorMessage(parameterName)));
        }
    }
    
