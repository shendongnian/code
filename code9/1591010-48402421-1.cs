    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            [...]
            SSLCertificateResolverConfigurator.Setup();
        }
    }
    //  for instructions on enabling IIS6 or IIS7 classic mode visit http://go.microsoft.com/?LinkId=9394801
