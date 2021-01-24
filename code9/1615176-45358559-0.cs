    public class UserController : ApiController
    {
        //
        // GET: /User/
        //[HttpGet]
        public string Register()
        {
            return "Register";
        }
       // [HttpPost]
        public string Register(int id)
        {
            return "register with id";
        }
