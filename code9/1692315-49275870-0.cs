        Step1: Check Your context class constructor enter code here`r should be like this
        
          public partial class ZPHSContext : DbContext
            {
                public ZPHSContext(DbContextOptions<ZPHSContext> dbContextOptions):base(dbContextOptions)`enter code here`
                {
        
                }
        
            }
        
        Step2: In Startup file register your context class
          public void ConfigureServices(IServiceCollection services)
                {
                    services.AddMvc();
                    services.AddDbContext<ZPHSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
        
                }
        
        Step3: Connection string in appsettings
        
        "ConnectionStrings": {
            "BloggingDatabase": "Server=Server=****;Database=ZPHSS;Trusted_Connection=True;"
          }
    Step4: Remove default code in OnConfiguring method in context class
    
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            }
