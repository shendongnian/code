    public class MvcApplication : System.Web.HttpApplication
    {
       protected void Application_Error(object sender, EventArgs e)
       {
           Exception exception = Server.GetLastError();
           Server.ClearError();
           string ip = Request.ServerVariables["REMOTE_ADDR"];
           Log(ip);
       }
    }
