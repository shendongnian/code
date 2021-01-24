    public class Startup {
        //. . .
    
        public void ConfigureServices(IServiceCollection services) {
            //. . . 
    
            //Register your context with dependency injection
            services.AddDbContext<HelperSqlDbContext>(options =>    
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            //register the context with its abstraction
            service.AddScoped<IHelperSqlContext, HelperSqlDbContext>()
            
            services.AddTransient<IHelper, MyHelper1>();
        }  
    }
