    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Try adding the following lines:
            var configuration = GlobalConfiguration.Configuration;
            var formatters = configuration.Formatters;
            formatters.Clear();
            formatters.Add(new JsonMediaTypeFormatter());
        }
        // A good idea to have this:
        protected void Application_Error()
        {
            Exception unhandledException = Server.GetLastError();
            // Set a breakpoint here or do something to log the exception
        }
