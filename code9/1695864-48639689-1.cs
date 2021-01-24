	[Produces("application/json")]
	[Route("api/JoeTests")]
	public class JoeTestsController : Controller
	{
        // route is now api/JoeTests/byid/5
		[HttpGet("byid/{id:int}")]
		public async Task<IActionResult> GetJoeTest([FromRoute] int id)
		{
		}
		
        // route is now api/JoeTests/bystr/whatever
		[HttpGet("bystr/{str}")]
		public async Task<IActionResult> GetJoeTest([FromRoute] string str)
		{
		}
	}
