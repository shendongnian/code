     public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
     {
        public bool Authorize(DashboardContext context)
        {
          var httpCtx = context.GetHttpContext();
          // Allow all authenticated users to see the Dashboard.
          return httpCtx.User.Identity.IsAuthenticated;
        }//Authorize
    }//Cls
