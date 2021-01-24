    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            //... Your other startup code
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
