	[Produces("application/json")]
	[Route("api/JoeTests")]
	public class JoeTestsController : Controller
	{
        // the :int restricts the route to integers
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetJoeTest([FromRoute] int id)
		{
		}
		
        // the route will match anything except integers
		[HttpGet("{str}")]
		public async Task<IActionResult> GetJoeTest([FromRoute] string str)
		{
		}
	}
