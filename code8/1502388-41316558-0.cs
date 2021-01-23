    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private ICityRepository _repository;
        public CitiesController(ICityRepository repository)
        {
            _repository = repository;
        }
        // GET: api/cities
        [HttpGet]
        public IEnumerable<City> Get()
        {
            IEnumerable<City> results = _repository.GetCities();
            return results;
        }
        //api/cities/date/2016/06/16
        [HttpGet]
        [Route("date/{year}/{month}/{day}")]
        public IEnumerable<City> Get2(string year,string month,string day)
        {
            string date = year + "/" + month + "/" + day;
            return _repository.GetCitiesByDate(date);
        }
      
        // GET api/cities/5
        [Route("{id: int}")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }
          //api/cities/pending
        [Route("{text}"]
        [HttpGet]
        public string Get(string text)
        {
            return "value";
        }
    }
 
