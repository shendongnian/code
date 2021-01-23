    [RoutePrefix("api")]
    public class SolutionsController:ApiController
    {
    
        [HttpGet]
        [Route("GetSolutionByCategory/{categoryId})"]
        public IHttpActionResult GetSolutionByCategory(int categoryId)
        {
            ....
        }
        [HttpGet]
        [Route("GetSolutions")]
        public IHttpActionResult GetSolutions()
        {
            ...
        }
    
    }
