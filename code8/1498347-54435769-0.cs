    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-AU");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-AU");
