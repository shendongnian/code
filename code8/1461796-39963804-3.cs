	public class CategoriesController : ApiController
	{
	  [HttpGet]
	  public IHttpActionResult Get()
	  
	  // or to pass in an an int and return only 1 category
	  [HttpGet]
	  public IHttpActionResult Get(int id)
	  
