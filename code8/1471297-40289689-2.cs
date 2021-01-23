    public partial class MyController {
        //GET resource/resourceName
        [HttpGet]
        [Route("{resourceName}")]
        public IHttpActionResult Get() { ... }
    }
