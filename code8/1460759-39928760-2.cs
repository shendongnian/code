    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class LogHeaderAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            ApiController apiController = (ApiController)args.Instance;
            var context = apiController.ControllerContext;
            HttpRequestHeaders headers = context.Request.Headers;
            
            // Use Web API request header info here
            string headerText = headers.GetValues("MyHeader").First();
        }
    }
