    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        [HttpGet("info/{Id}")]
        public async Task<Data> Get(string Id)
        {
            //Logic
            var myRoute = Url.RouteUrl(RouteData.Values);
        }
    }
