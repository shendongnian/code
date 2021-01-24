    public class UserController : ApiController
    {
    
        public IHttpActionResult Post(User user)
        {
            //Controller logic
            TestHelper.DoSomething();
    
        }
    }
