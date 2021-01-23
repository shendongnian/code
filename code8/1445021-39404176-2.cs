    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly Func<Dictionary<string, object>, bool> _validate;
        public ValidateModelAttribute()
            : this(arguments =>
                arguments.ContainsValue(null))
        { }
        public ValidateModelAttribute(Func<Dictionary<string, object>, bool> checkCondition)
        {
            _validate = checkCondition;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
                actionContext.Response = actionContext.Request
                     .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
              }
    }
