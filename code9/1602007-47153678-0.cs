    public class ValidateModelAttribute : ActionFilterAttribute{
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        if (actionContext.ModelState.IsValid == false)
        {
            var error = new
            {
                status = false,
                message = "The request is invalid.",
                error = actionContext.ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
            };
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, error);
        }
    }}
