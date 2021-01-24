    public class UserDestroyerMiddleware
    {
        private readonly RequestDelegate _next;
    
        public UserDestroyerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext httpContext, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            if(!string.IsNullOrEmpty(httpContext.User.Identity.Name))
            {
                var user = await userManager.FindByNameAsync(httpContext.User.Identity.Name);
                //You may have a better property to check here
                if(user.LockoutEnabled)
                {
                    await signInManager.SignOutAsync();
                }
            }    
            await _next(httpContext);
        }
    }
