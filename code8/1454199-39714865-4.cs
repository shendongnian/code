      <system.web>
        <customErrors defaultRedirect="~/Common/Error" mode="On">
          <error statusCode="404" redirect="~/Common/PageNotFound"/>
        </customErrors>
      </system.web>
    public class CommonController : Controller
    {
    	[AllowAnonymous]
    	public ActionResult Error()
    	{
            var exception = Server.GetLastError(); <--- Get Exception
    
    		Response.StatusCode = 503;
    		Response.TrySkipIisCustomErrors = true;
    
    		return View();
        }	
    }
