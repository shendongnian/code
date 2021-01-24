    [Route("/", Name = "DefaultTelemetry")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MyData_Controller : ApiController {
        [HttpPost]
        [AllowAnonymous]
        [ActionName("DefaultAction")]
        [Route("")] //Matches POST / <-- site root
        public async Task<IHttpActionResult> Post([FromBody]String data) {
            var saved = await SaveData(data);
            return saved ? Ok() : BadRequest();
        }
    
        protected Task<bool> SaveData(String data) {
            //...implementation
        }
    }
