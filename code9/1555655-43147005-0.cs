    public class cController : ApiController {
    
        [HttpPut]
        public IHttpActionResult Put(string id,[FromBody] Model body) {
            if(ModelState.IsValue) {    
                return Ok(body.text1);
            }
            return BadRequest();
        }
    }
