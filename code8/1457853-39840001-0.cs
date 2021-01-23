    public class CommoditiesController : Controller
    {
        //Declare the local variable
        ICommodityRepository _commodities;
        //Load the repository via DI
        public CommoditiesController(CommodityRepository commodities)
        {
            //Set the local variable to the injected one
            _commodities = commodities;
        }
    
        // GET: /<controller>/
        public IEnumerable<Commodity> CommoditiesList()
        {
            //Reference the local variable in your methods
            return _commodities.GetAll();
        }
    }
