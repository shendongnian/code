    public class CustomDefaultHttpControllerSelector: DefaultHttpControllerSelector
    {
        public CustomDefaultHttpControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
        }
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            HttpControllerDescriptor descriptor = null;
            try
            {
                descriptor = base.SelectController(request);
            }
            catch (HttpResponseException e)
            {
                var routeValues = request.GetRouteData().Values;
                routeValues.Clear();
                routeValues["controller"] = "Error";
                routeValues["action"] = "Main";
                routeValues["code"] = e.Response.StatusCode;
                routeValues["language"] = request.Headers?.AcceptLanguage?.FirstOrDefault()?.Value ?? "en";
                descriptor = base.SelectController(request);
            }
            return descriptor;
        }
    }
    public class CustomControllerActionSelector: ApiControllerActionSelector
    {
        public CustomControllerActionSelector()
        {
        }
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            HttpActionDescriptor descriptor = null;
            try
            {
                descriptor = base.SelectAction(controllerContext);
            }
            catch (HttpResponseException e)
            {
                var routeData = controllerContext.RouteData;
                routeData.Values.Clear();
                routeData.Values["action"] = "Main";
                routeData.Values["code"] = e.Response.StatusCode;
                routeData.Values["language"] = controllerContext.Request?.Headers?.AcceptLanguage?.FirstOrDefault()?.Value ?? "en";
                IHttpController httpController = new ErrorController();
                controllerContext.Controller = httpController;
                controllerContext.ControllerDescriptor = new HttpControllerDescriptor(controllerContext.Configuration, "Error", httpController.GetType());
                descriptor = base.SelectAction(controllerContext);
            }
            return descriptor;
        }
    }
