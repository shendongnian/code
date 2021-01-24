    // using Microsoft.Extensions.Configuration;
    
    public class YourController : Controller
    {
          public YourController (IConfiguration configuration)
          {
               var connString = Configuration.GetConnectionString("MyContext");
          }
    
    }
