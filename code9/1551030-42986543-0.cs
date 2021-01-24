    [RoutePrefix("api/MobileStations")]
    public class MobileStationsController : ApiController {
       
        /// <summary>
        /// Gets all clients
        /// </summary>
        /// <returns>All clients</returns>
        [HttpGet]
        [ActionName(nameof(GetMobileStationsAsync))]
        [Route("", Name = "GetMobileStations")] //GET api/MobileStations
        public async Task<IEnumerable<MobileStation>> GetMobileStationsAsync() { ... }
    }
