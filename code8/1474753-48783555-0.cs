	//In Startup.ConfigureServices()
    var clientConfig = Configuration.GetSection("configuredClients")
		.Get<ClientConfiguration>();
    services.AddSingleton(clientConfig);
    //Controller
	public class TestController : Controller
	{
		IConfiguration _configStore;
		ClientConfiguration _clientConfiguration;
			
		public TestController(IConfiguration configuration, 
			ClientConfiguration clientConfiguration)
		{
			_configStore = configuration;
			_clientConfiguration = clientConfiguration;
		}
		
		public IActionResult Get()
		{
			//with IConfiguration
			var clientId1 = _configStore
				.GetValue<string>("configuredClients:clients:0:clientId");
			//with strongly typed ClientConfiguration
			var clientName1 = _clientConfiguration.Clients[0]?.ClientName;
			return new OkObjectResult("Configuration test");
		}
	}
