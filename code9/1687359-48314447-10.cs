    public class CustomRequirementHandler : AuthorizationHandler<CustomRequirement>
    {
        private readonly ITempDataProvider _tempDataProvider;
    
        public CustomRequirementHandler(ITempDataProvider tempDataProvider)
        {
            _tempDataProvider = tempDataProvider;
        }
    
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
        {
            ///////
            //Your logic
            ///////
            context.Fail();
            
    
            if (context.HasFailed && context.Resource is AuthorizationFilterContext mvcContext)
            {
                _tempDataProvider.SaveTempData(mvcContext.HttpContext, new Dictionary<string, object>() {  { "message","alertmessage "+DateTime.Now } });
            }
    
            return Task.CompletedTask;
        }
    }
