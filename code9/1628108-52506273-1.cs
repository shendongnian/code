    public class MyEventsWrapper : CookieAuthenticationEvents
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IDependency _otherDependency;
        public MyEventsWrapper(IHttpContextAccessor accessor,
                               IDependency otherDependency)
        {
            _accessor = accessor;
            _otherDependency = otherDependency;
        }
        public override async Task RedirectToLogin(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.Headers.Remove("Location");
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await _otherDependency.Cleanup(_accessor.HttpContext);
        }
    }
