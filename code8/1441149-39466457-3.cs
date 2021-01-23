    namespace WebApplication2.Controllers
    {
        public class CityController : ApiController
        {
            public IEnumerable<City> Get()
            {
                IEnumerable<City> cities;
                using (var context = new App2Context())
                {
                    cities = context.Cities.Include(c => c.ApplicationUser).ToList();
                }
                return cities;
            }
        }
    }
