    public class Startup {
    
        public void ConfigureServices(IServiceCollection services) {
            //...
        
            services.AddMyLibraryDbContext(Configuration);
        
            services.AddMvc();
        }
    }
