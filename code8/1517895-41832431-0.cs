    [Authorize]
    public class MyApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetDataForLoggedUser()
        {
            var userName = HttpContext.Current.User.Identity.Name;
            // retrieve data for specific user...
            return Ok();
        }
    }
