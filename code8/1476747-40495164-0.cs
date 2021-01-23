    namespace HttpClientPostWebService.Controllers
    {
        public class SwipesController : ApiController
        {
            [System.Web.Http.HttpGet]
            public IHttpActionResult SaveSwipeToServer(int locationId, int userId, int ebCounter, long dateTimeTicks, int swipeDirection, int serverTime)
            {
                return Ok(new SwipeResponse
                {
                    TestInt = 3,
                    TestString = "Testing..."
                });
            }
    
            [System.Web.Http.HttpPost]
            public IHttpActionResult PostSwipeToServer([FromBody] SwipeRequest req)
            {
                return Ok(new SwipeResponse
                {
                    TestInt = 3,
                    TestString = "Testing..."
                });
            }
    
        }
    
        public class SwipeRequest
        {
            public string TestStringRequest { get; set; }
            public int TestIntRequest { get; set; }
        }
    
        public class SwipeResponse
        {
            public string TestString { get; set; }
            public int TestInt { get; set; }
        }
    }
