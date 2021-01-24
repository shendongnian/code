    public class Startup
    {
        private IMyInterface _myService;
    
        public void ConfigureServices(IServiceCollection services)
        {
        }
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _myService = new MyConcreteTpye(app.ApplicationServices.GetService<MyEntityFrameworkContext>(), Configuration["Data"]);
        }
    }
