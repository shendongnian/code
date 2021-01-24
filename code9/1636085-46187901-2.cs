    class YourController : Controller{
       YourClass _testing;
       YourController(IOptions<ConnectionConfig> connectionConfig){
           var connection = connectionConfig.Value;
           string connectionString = connection.Analysis;
           _testing = new YourClass(connectionString );
        }
       public IActionResult Index() { 
            var testingData = _testing.ReadAll(); 
            return View(); 
         }
     }
