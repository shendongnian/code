    public class ExampleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        public ExampleService(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }
        public void DoSomething()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionaryFactory.GetTempData(httpContext);
            // use tempData as usual
            tempData["Foo"] = "Bar";
        }
    }
