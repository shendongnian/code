    [Produces("application/json")]
    [Route("api/Heroes")]
    public class HeroesController : Controller
    {
        [HttpGet]
        [NoCache]
        //GET: api/Heroes
        //GET: api/Heroes?searchTerm=
        public JsonResult Get(string searchTerm) //string is nullable, so it's good for optional parameters
        {
            if (searchTerm == null)
            {
            ...
            }
            else
            {
            ...
            }
        }
    }
