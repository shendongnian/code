    namespace WebApiExperiment.Controllers
    {
        [RoutePrefix("api/routingMatters")]
        public class HomeController : ApiController
        {
            [Route("magic")]
            public IHttpActionResult Index(SendCodeViewModel sendView)
            {
                return Ok();
            }
            [Route("magic2")]
            public IHttpActionResult About(SendCodeViewModel sendView)
            {
    
                return Ok("Your application description page.");
            }
            [Route("magic3")]
            public IHttpActionResult Contact(SendCodeViewModel sendView)
            {
                return Ok("Your contact page.");
            }
        }
    }
