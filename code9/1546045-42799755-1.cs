    	public class SimpleAuthorizeAttribute : AuthorizeAttribute
		{
		
			protected override bool AuthorizeCore(HttpContextBase httpContext)
			{
			   if(Session["IsLogin"] != null && Session["IsLogin"] == true)
			   {
				  return true;
			   }
			   else
			   {
				  return false;
			   }
			}
		}
