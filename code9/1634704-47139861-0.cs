    public class TestService{
      public TestService(FooDbContext db)
        {
            this.db = db;
        }
    }
    public class FooController{
     public FooController(FooDbContext db, TestService testService) 
     {
            this.testService = testService;
            this.db = db;
     }
    }
    public class Startup{
      public void ConfigureServices(IServiceCollection services){
          //...
          services.AddDbContext<FooDbContext>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("FooDbContext"))
          );
          services.AddSingleton<TestService>();
      }
    }
