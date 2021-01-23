    public class SessionAppAdminAuthorization : IAppAdminAuthorization
    {
        private readonly IHttpContextAccessor accessor;
        public SessionAppAdminAuthorization(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
        public void DoSomethingUseful() {
            if (this.accessor.HttpContext.Session.GetBoolean("IsAdmin")) {
                // ...
            } else {
                // ...
            }
        }
    }
