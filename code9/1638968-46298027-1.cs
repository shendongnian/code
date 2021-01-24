    public class RoleController : ApiController
    {       
        [HttpPost]
        public Result Delete([FromBody]int RoleID)
        {
            return RoleBL.Delete(RoleID);
        }
    }
