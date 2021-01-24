    public class ClientsController : ControllerBase
    {
        private readonly IConfigurationDbContext _configurationDbContext;
    
        public ClientsController(IConfigurationDbContext configurationDbContext)
        {
            _configurationDbContext = configurationDbContext;
        }
        // ...
    }
