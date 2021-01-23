    public class someController : ApiController
        {
            [Route("api/test/{name}"), HttpGet]
            public string Router(string name)
            {
                return "Your name is: " + name;
            }        
         }
