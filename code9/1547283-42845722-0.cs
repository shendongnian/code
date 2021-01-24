    using System.Diagnostics;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters; <--- WebAPI assembly 
    
    namespace YOURNAMESPACE
    {
        public class BasicTokenValidation : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                HttpContext.Current.Response.Write(" filter1 ");
                Debug.WriteLine("Executing My Filter!");
                if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
                else
                {
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;
                }
    
                base.OnActionExecuting(actionContext);
            }
        }
    }
