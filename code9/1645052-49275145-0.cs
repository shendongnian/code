    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync<T>(string viewName, T model) where T : PageModel;
    }
    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IActionContextAccessor _actionContext;
        private readonly IRazorPageActivator _activator;
        public ViewRenderService(IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider,
            IHttpContextAccessor httpContext,
            IRazorPageActivator activator,
            IActionContextAccessor actionContext)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _httpContext = httpContext;
            _actionContext = actionContext;
            _activator = activator;
        }
        public async Task<string> RenderToStringAsync<T>(string pageName, T model) where T : PageModel
        {
            var actionContext =
                new ActionContext(
                    _httpContext.HttpContext,
                    _httpContext.HttpContext.GetRouteData(),
                    _actionContext.ActionContext.ActionDescriptor
                );
            using (var sw = new StringWriter())
            {
                var result = _razorViewEngine.FindPage(actionContext, pageName);
                if (result.Page == null)
                {
                    throw new ArgumentNullException($"The page {pageName} cannot be found.");
                }
                var view = new RazorView(_razorViewEngine,
                    _activator,
                    new List<IRazorPage>(),
                    result.Page,
                    HtmlEncoder.Default,
                    new DiagnosticListener("ViewRenderService"));
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    new ViewDataDictionary<T>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = model
                    },
                    new TempDataDictionary(
                        _httpContext.HttpContext,
                        _tempDataProvider
                    ),
                    sw,
                    new HtmlHelperOptions()
                );
                var page = ((Page)result.Page);
                page.PageContext = new Microsoft.AspNetCore.Mvc.RazorPages.PageContext
                {
                    ViewData = viewContext.ViewData
                };
                page.ViewContext = viewContext;
                _activator.Activate(page, viewContext);
                await page.ExecuteAsync();
                return sw.ToString();
            }
        }
    }
