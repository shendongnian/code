      public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
       
        public static bool VaidateUserRoleWise(string username, string password, int RoleId)
        {
            //DO DATABASE CONNECTION DO QUERY HERE 
            if (Username == username && Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void OnAuthorization(QuizzrApi.Controllers.QuizzrController.InputParamAdminLogin LoginDetails)
        {
            System.Web.Http.Controllers.HttpActionContext actionContext = null;
            if (LoginDetails == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                //Bellow is the static method called above will return true or false if user matches
                if (!VaidateUserRoleWise(LoginDetails.UserName, LoginDetails.Password, 1))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            base.OnAuthorization(actionContext);
        }
       
    }
