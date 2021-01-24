    // StartUp.cs
    public void ConfigureServices(IServiceCollection services)
    {
    	...
    	// for get appsettings from anywhere
    	services.AddSingleton(Configuration);
    }
    
    public class ContactUsController : Controller
    {
    	readonly IConfiguration _configuration;
    
    	public ContactUsController(
    		IConfiguration configuration)
    	{
    		_configuration = configuration;
    		
    		// sample:
    		var apiKey = _configuration.GetValue<string>("SendGrid:CAAO");
    		...
    	}
    }
