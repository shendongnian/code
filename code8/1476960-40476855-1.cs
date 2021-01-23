    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController {
        private IMenuRepo xMenuRepo;
        public MenuController(IMenuRepo iopt) {
            xMenuRepo = iopt;
        }
        //GET api/Menu
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetOk() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
