    public class ClubAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            int clubId;
            int.TryParse((string) actionContext.ActionArguments["clubId"], out clubId);
            if (!UserCanManageClub(clubId))
            {
                return false;
            }
            return base.IsAuthorized(actionContext);
        }
    }
