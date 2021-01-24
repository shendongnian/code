    public class RoleController : ApiController
    {       
        [HttpPost,HttpDelete]
        // OR
        [AcceptVerbs("DELETE", "POST")
        public Result Delete([FromBody]int RoleID)
        {
            return RoleBL.Delete(RoleID);
        }
    }
