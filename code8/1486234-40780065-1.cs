        // Restrict unauthorized access:       
        [Authorize]  
        public class ValuesController : ApiController
        {
        }
        // Restrict by user:
        [Authorize(Users="Prashant,Lua")]
        public class ValuesController : ApiController
        {
        }
       // Restrict by role:
       [Authorize(Roles="Administrators")]
       public class ValuesController : ApiController
       {
       }
