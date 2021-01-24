    namespace solution.Controllers
    {
      public class ExampleController : ApiController
      {
        [HttpPost]
        [Route("api/Example")]
        [System.Web.Http.Authorize]
        public void Run()
        {
           // do something;
        }
      }  
    }
