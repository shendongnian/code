    public class CustomRequirementHandler : AuthorizationHandler<CustomRequirement>
        {
            private readonly IHttpContextAccessor _httpContext;
            private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
    
            public CustomRequirementHandler(IHttpContextAccessor httpContext, ITempDataDictionaryFactory tempDataDictionary)
            {
                _httpContext = httpContext;
                _tempDataDictionaryFactory = tempDataDictionary;
            }
    
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
            {
                ///////
                //Your logic
                ///////
    
                if (context.HasFailed)
                {
                    var tempData = _tempDataDictionaryFactory.GetTempData(_httpContext.HttpContext);
                    tempData["message"] = "alert message";
                }
    
                return Task.CompletedTask;
            }
        }
