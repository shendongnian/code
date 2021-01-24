    public class MvcApplication : System.Web.HttpApplication
    {
        public static void Register()
        {
            //registering an HttpModule
            HttpApplication.RegisterModule(typeof(LogModule));
        }
        ....
    }
    public class LogModule: IHttpModule
    {
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.LogRequest += LogEvent;
        }
        private void LogEvent(object src, EventArgs args)
        {
            if (HttpContext.Current.CurrentNotification == RequestNotification.LogRequest)
            {
                if ((MvcHandler)HttpContext.Current.Handler != null)
                {
                    Debug.WriteLine("This was logged!");
                    //Save the information to your file
                }
            }
        }
    }
