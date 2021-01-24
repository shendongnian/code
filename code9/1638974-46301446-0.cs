    public class RoleController : ApiController
    {       
        [HttpPost]
        public IHttpActionResult DeleteRole([FromBody]int RoleID)
        {
            if ( RoleID <= 0 )
            {
                  return BadRequest();
            }
    
            var deleteResult = RoleBL.Delete(RoleID);
            return Ok(deleteResult);
        }
    }
