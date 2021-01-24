    [RoutePrefix("api/NCT_ProcessSettings")]
    public class NCT_ProcessSettingsController : ApiController {
    
        //GET api/NCT_ProcessSettings
        [HttpGet]
        [Route("")]
        public IEnumerable<Process_Settings> Get() { ... }
    
        //GET api/NCT_ProcessSettings/5
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id) { ... }
    
        //GET api/NCT_ProcessSettings/GetGlobalSettings
        [HttpGet]
        [Route("GetGlobalSettings")]
        public IEnumerable<NCT_Process_Settings> GetGlobalSettings() { ... }
    }
