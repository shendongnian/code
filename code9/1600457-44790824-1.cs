    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
       {
          ...
          services.AddMvc();
          services.AddAutoMapper();
       }
    }
