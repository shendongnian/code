    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validationErrorResponse = new Dictionary<string, Object>();
                validationErrorResponse["message"] = "The request has validation errors";
                validationErrorResponse["errors"] = new SerializableError(context.ModelState);
                context.Result = new BadRequestObjectResult(validationErrorResponse);
            }
        }
    }
