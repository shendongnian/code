    [Route("api/[controller]")]
    public class ValuesController : Controller {
        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery][ModelBinder(Name = "A")]QueryParameters parameters) {    
            if(ModelState.IsValid) {
                return Ok(new [] { parameters.A.ToString(), parameters.B.ToString() });
            }
            return BadRequest();
        }        
    }
