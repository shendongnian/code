	[RoutePrefix("api/categories"]
	public class CategoriesController : ApiController
	{
	  [HttpGet]
	  [Route("")]
	  public IHttpActionResult GetCategories()
	  
	  [HttpGet]
	  [Route("{id:int}")]
	  public IHttpActionResult GetCategory(int id)
