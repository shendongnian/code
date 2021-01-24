    public class ValidateQueryParametersFilterAttribute : ActionFilterAttribute
    {
        private IEnumerable<string> _validQueryParameters;
    
        public ValidateQueryParametersFilterAttribute(params string[] validQueryParameters)
        {
            if (validQueryParameters != null)
            {
                _validQueryParameters = validQueryParameters.Where(x => !string.IsNullOrWhiteSpace(x));
            }
        }
    
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.GetQueryNameValuePairs().Any(x => !_validQueryParameters.Contains(x.Key)))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You sent me an invalid property.");
            }
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
