    public class Location
    {
        //properties here that describe a location
    }
    
    public class CsvHelperLocationRepository : ILocationRepository
    {
        private readonly string _dataFileLocation;
    
        public CsvHelperLocationRepository(string dataFileLocation)
        {
            _dataFileLocation = dataFileLocation;
        }
    
        public List<Location> GetLocations()
        {
            //use CsvHelper here to parse the CSV file and generate a list of Location objects to return
        }
    }
    
    public interface ILocationRepository
    {
        List<Location> GetLocations();
    }
    
    public HomeController : Controller
    {
        private readonly ILocationRepository _locationRepository;
    
        public HomeController()
        {
             //you really should use dependency injection instead of direct dependency like below
             _locationRepository = new CsvHelperLocationRepository(Server.MapPath("~/data/locations.csv");
        }
    
        public ActionResult SomeAction()
        {
            var model = new MyViewModel();
            model.Locations = _locationRepository.GetLocations();
            return View(model);
        }
    }
