        public class CheckSession: ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
               var MySession = HttpContext.Current.Session
                
               if(MySession["Account_ID"] == null || MySession["Account_UserName"]== null)
               {
                  filterContext.Result = new RedirectResult(string.Format("/Account/"));
               }  
            }
        }
