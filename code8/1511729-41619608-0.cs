    namespace MyApp.WebApi.Controllers
    {
        [RoutePrefix("api/listing")]
        public class ListingController : ApiController
        {
            [Route("")]
            public IEnumerable<ListItem> Get([FromUri] ClassRepresentingParams params)
            {
