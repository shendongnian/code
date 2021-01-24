    public class ClientUserApi : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            WebRequestState webRequestState = ContainerHome.Container.Resolve<WebRequestState>();
            ActionDescriptor actionDescriptor = filterContext.ActionDescriptor;
            if (actionDescriptor.IsDefined(typeof(StaffUserAuthorizeAttribute), true))
                return;
            if (!webRequestState.IsAuthenticated || webRequestState.ClientUser == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;         // 401, always show log-in page
            }            
        }
    }  
