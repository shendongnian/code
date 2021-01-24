    public class HomeController : Controller
    {
        private readonly DatabaseConnections _databaseConnections;
    
        public HomeController(IOptions<DatabaseConnections> databaseConnections)
        {
            _databaseConnections = databaseConnections.Value;
        }
    }
