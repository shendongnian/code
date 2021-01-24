    [RoutePrefix("api/NCT_ProcessSettings")]
    public class NCT_ProcessSettingsController : ApiController {
    
        //GET api/NCT_ProcessSettings
        [Route("")]
        public IEnumerable<Process_Settings> Get() { ... }
    
        //GET api/NCT_ProcessSettings/5
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id) { ... }
    
        //GET api/NCT_ProcessSettings/GetGlobalSettings
        [Route("GetGlobalSettings")]
        public IEnumerable<NCT_Process_Settings> GetGlobalSettings() { ... }
    }
