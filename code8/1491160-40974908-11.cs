    public class ValidationActionFilter : BaseActionFilterAttribute
    {
        // This must run AFTER the FluentValidation filter, which runs as 0
        public ValidationActionFilter() : base(1000) { }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (modelState.IsValid) return;
            var errors = new ErrorModel();
            foreach (KeyValuePair<string, ModelState> item in actionContext.ModelState)
            {
                errors.ModelErrors.AddRange(item.Value.Errors.Select(e => new ModelPropertyError
                {
                    PropertyName = item.Key,
                    ErrorMessage = e.ErrorMessage
                }));
            }
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
        }
    }
