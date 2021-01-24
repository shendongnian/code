    [RoutePrefix("~/Role")]
    public class RoleController : ApiController
    {
        
        [HttpPost]
        [Route("~/Delete")]
        public Result Delete([FromBody]int RoleID)
        {
            return RoleBL.Delete(RoleID);
        }
    }
