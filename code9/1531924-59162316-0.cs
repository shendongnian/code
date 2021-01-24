    public class MvcValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private IModelMetadataProvider ModelMetadataProvider { get; }
        public MvcValidationExceptionFilterAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            ModelMetadataProvider = modelMetadataProvider;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Framework calls without null")]
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException ex)
            {
                var validationResult = new ValidationResult(ex.Errors);
                validationResult.AddToModelState(context.ModelState, null);
                context.Result = new ViewResult { ViewData = new ViewDataDictionary(ModelMetadataProvider, context.ModelState) };
                context.ExceptionHandled = true;
            }
        }
    }
