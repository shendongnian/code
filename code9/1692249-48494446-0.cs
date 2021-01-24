    [Route("api/[controller]")]
    public class HospitalController : Controller {
    
        //...code removed for brevity
    
        //Matches GET api/Hospital/GetById/5
        [HttpGet("GetById/{id:int}")]
        public IActionResult Get(int id) {
            return Ok(_hospitalService.Get(id));
        }
    }
