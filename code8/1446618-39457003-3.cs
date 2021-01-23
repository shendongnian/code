    namespace BeerDev.ControllersApi
    {
        public class HomeController : ApiController
        {
            public IHttpActionResult Get()
            {
                string beers;
                using (StreamReader sr = new StreamReader(HostingEnvironment.MapPath("~/mockData/beerFront.json")))
                {
                    beers = sr.ReadToEnd();
                }
    
                if (string.IsNullOrEmpty(beers))
                {
                    return NotFound();
                }
                return Ok(beers);
            }
        }
    }
