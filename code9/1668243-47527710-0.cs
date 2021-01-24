    public class HomeController : Controller {
        private readonly string _connectionString;
        public HomeController(IConfiguration config) {
            _connectionString = config.GetConnectionString("MyContext");
        }
    }
