    public class CustomAuthorizationAttribute : ActionFilterAttribute
    {
        private readonly IMyDepedency _dp;
        public CustomAuthorizationAttribute(IMyDepedency dp)
        {
            _dp = dp;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isValid = false;
           //write my validation and authorization logic here 
            if(!isValid)
            {
                var unauthResult = new UnauthorizedResult();
                
                context.Result = unauthResult;                
            }
            base.OnActionExecuting(context);
        }
    }
