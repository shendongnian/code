    public class MyApiController : ApiController {
        private readonly IDtoService dtoService;
    
        public MyApiController (IDtoService dtoService) {
            this.dtoService = dtoService;
        }
    
        public IHttpActionResult PutSomething(string ParameterId) {
            var result = dtoService.MyReuseMethod(ParameterId, false);
            if(result == null) return NotFound();
            if(result == false) return BadRequest();
            return Ok();
        }
    }
