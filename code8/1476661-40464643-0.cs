    namespace testWEBAPI.Controllers
    {
        public class MyapiController : ApiController
        {
            public List<student> s = new List<student>()
            {
            new student{name="krishna",city="hyderbad"},
            new student{name="priya",city="mumbai"},
            new student{name="sandeep",city="jamshedpur"}
            };
            
            public HttpResponseMessage getnames()
            {
                string name = list.Select(x=>x.name).ElementAt(0);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, name);
    			return response;
            }
        }
    }
