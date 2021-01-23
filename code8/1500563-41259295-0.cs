    class SampleFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            if (/* some condition */)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                // go ahead
            }
        }
    }
