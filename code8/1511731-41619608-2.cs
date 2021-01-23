    namespace MyApp.WebApi.Controllers
    {
        [RoutePrefix("api/listing")]
        public class ListingController : ApiController
        {
            [Route("")]
            [HttpGet]
            public IEnumerable<ListItem> Get([FromUri] ClassRepresentingParams params)
            {
