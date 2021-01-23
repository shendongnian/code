    public class HomeController
    {
        public IMongoDatabase Database;
        public HomeController()
        {
            var client = new MongoClient(Settings.Default.RealEstateConnectionString);
            Database = client.GetDatabase(Settings.Default.RealEstateDatabaseName); //This is the line with the error...            
        }
        public ActionResult Index()
        {
            Database.GetStats();
            return Json(Database.Server.BuildInfo, JsonRequestBehavior.AllowGet);
        }
    }
