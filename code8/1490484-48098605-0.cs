    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostingEnvironment _env;
        private readonly HttpContext _http;
        public ViewRenderService(IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider, IHostingEnvironment env, IHttpContextAccessor ctx)
        {
            _razorViewEngine = razorViewEngine; _tempDataProvider = tempDataProvider; _serviceProvider = serviceProvider; _env = env; _http = ctx.HttpContext;
        }
        public async Task<string> RenderToStringAsync(string viewName, object model)
        {
            var actionContext = new ActionContext(_http, new RouteData(), new ActionDescriptor());
            using (var sw = new StringWriter())
            {
                var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);
                //var viewResult = _razorViewEngine.GetView(_env.WebRootPath, viewName, false); // For views outside the usual Views folder
                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} does not match any available view");
                }
                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };
                var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary, new TempDataDictionary(_http, _tempDataProvider), sw, new HtmlHelperOptions());
                viewContext.RouteData = _http.GetRouteData();
                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }
    }
