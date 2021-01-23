    // Application-specific abstraction (part of your application's core layer)
    public interface IUserContext
    {
        bool IsAdmin { get; }
    }
    // Adapter implementation (placed in the Composition Root of your web app)
    public class AspNetSessionUserContextAdapter : IUserContext
    {
        private readonly IHttpContextAccessor accessor;
        public AspNetSessionUserContextAdapter(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
        public bool IsAdmin => this.accessor.HttpContext.Session.GetBoolean("IsAdmin");
    }
    // Improved version of SessionAppAdminAuthorization
    public class SessionAppAdminAuthorization : IAppAdminAuthorization
    {
        private readonly IUserContext userContext;
        // This class can now be moved to the business layer, since there's no
        // more dependency on ASP.NET.
        public SessionAppAdminAuthorization(IUserContext userContext) {
            this.userContext = userContext;
        }
        public void DoSomethingUseful() {
            if (this.userContext.IsAdmin) {
                // ...
            } else {
                // ...
            }
        }
    }
