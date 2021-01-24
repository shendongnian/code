    [Authorize]
    [RoutePrefix("Users")]
    public class UsersController : ApiController {
    
        [HttpDelete]
        [Route("DeleteUser/{id:int}")] //Matches DELETE {root}/Users/DeleteUser/5
        public IHttpActionResult Delete(int id) {
            //TODO: check if {id} exists and if not, then return NotFound()
            _UserRepository.Delete(id);
            return Ok();
        }
      
        //...other members
    }
