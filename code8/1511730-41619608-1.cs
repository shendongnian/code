    namespace MyApp.WebApi.Controllers
    {
        [RoutePrefix("api/listing")]
        public class ListingController : ApiController
        {
            [HttpGet("")]
            public IEnumerable<ListItem> Get([FromUri] ClassRepresentingParams params)
            {
