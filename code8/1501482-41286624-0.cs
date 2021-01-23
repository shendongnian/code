    [RoutePrefix("api/nestedSet")] //<<======
    public class NestedSetController : ApiController
    {
        [Route("myaction01")] //<<======
        [HttpGet]
        public async Task<int> Myaction01_differentName()
        {
           //the call will be: http://mydomain/api/nestedSet/myaction01
           //code here...
           return 0;
        }
        [Route("myaction02")] //<<======
        [HttpGet]
        public async Task<int> Myaction02_differentName()
        {
           //the call will be: http://mydomain/api/nestedSet/myaction02
           //code here...
           return 0;
        }
    }
