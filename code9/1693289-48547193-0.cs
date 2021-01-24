    public class NewBaseController : Controller
    {
        protected UserManager<MyUser> UserManager;
        protected MyUser CurrentUser;
        protected ILogger Logger;
     
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
    
            UserManager = context.HttpContext.RequestServices.GetService<UserManager<MyUser>>();
                
            var loggerFactory = context.HttpContext.RequestServices.GetService<ILoggerFactory>();
            Logger = loggerFactory.CreateLogger(GetType());
            // Check if Action is annotated with [AllowAnonymous]
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var anonymousAllowed = controllerActionDescriptor.MethodInfo
                .GetCustomAttributes(inherit: true)
                .Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute)));
    
            if (!anonymousAllowed)
            {
                ApplicationUser = UserManager.GetUserAsync(User).Result;
                if (ApplicationUser == null)
                    // do some stuff
                Logger.LogInformation("User is {UserId}", CurrentUser.Id);
            }
            else
            {
                Logger.LogInformation("User is {User}", anonymous);
            }
        }
     }
