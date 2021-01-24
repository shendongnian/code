    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly HttpContext _context;
        public ViewRenderService(IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider,
            IHttpContextAccessor accessor)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _context = accessor.HttpContext;
        }
        public async Task<string> RenderToStringAsync(string viewName, object model)
        {
            var actionContext = new ActionContext(_context, new RouteData(), new ActionDescriptor());
            using (var sw = new StringWriter())
            {
                var viewResult = _razorViewEngine.GetView(viewName, viewName, false);
                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} does not match any available view");
                }
                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };
                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );
                viewContext.RouteData = _context.GetRouteData();
                await viewResult.View.RenderAsync(viewContext);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
