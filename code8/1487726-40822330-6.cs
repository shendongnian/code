    using System.Text;
    using System.Security.Cryptography;
    using System.Web.Http.Filters;
    using System.Web.Http.Controllers;
    using System.Net.Http;
      public class RequireHttpsAttribute : AuthorizationFilterAttribute
        {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                if (actionContext.Request.RequestUri.Scheme !=Uri.UriSchemeHttps)
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                    {
                        ReasonPhrase = "HTTPS Required"
                    };
                }
                else
                {
                    string UserName; 
                    String Password;
                    if (actionContext.Request.Headers.Any(p => p.Key == "UserName") &&
		        actionContext.Request.Headers.Any(p => p.Key == "UserName"))
                    {
                        UserName = actionContext.Request.Headers.Where(p => p.Key ==                    		    		    "UserName").FirstOrDefault().Value.FirstOrDefault();
		    
		        Password = actionContext.Request.Headers.Where(p => p.Key ==                    		    		    "UserName").FirstOrDefault().Value.FirstOrDefault();
                    
	                //do authentication stuff here..
		        If(Authorized())
			    {
				     base.OnAuthorization(actionContext);
                        	     return;
			    }
		        Else
			{
				    actionContext.Response = new HttpResponseMessage							(System.Net.HttpStatusCode.Forbidden)
                		    {
                    			    ReasonPhrase = "Invalid User or Password"
               		 	    };
			    }
                    }
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                    {
                        ReasonPhrase = "HTTPS Required"
                    };
               
               
                }
            }
            return ReasonPhrase;
        }
