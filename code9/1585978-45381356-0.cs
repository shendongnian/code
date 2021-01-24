    using System.Web;
    using System.Web.Helpers;
    // ...
    
    namespace AntiForgeryStrategiesPreCore
    {
        public class MvcApplication : HttpApplication
        {
            protected void Application_Start()
            {
                // ...
                AntiForgeryConfig.AdditionalDataProvider = new MyAdditionalDataProvider();
            }
        }
    }
