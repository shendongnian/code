    public class RequestNoValidoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    RequestMessage = actionContext.Request,
                    Content = new StringContent("Formato no válido.")
                };
                actionContext.Response = response;
            }
        }
    }
