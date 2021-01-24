	// ...
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[HttpGet("{id}", Name = "RouteForDerivedControllerA")]
	public virtual Task<IActionResult> Get(int id)
	{
		return base.Get(id);
	}
}
    public abstract class BaseController<TEntity, TContext> : Controller where TEntity : BaseOptionType, new() where TContext : DbContext
    {
    	// ...
    
    	public virtual async Task<IActionResult> Get(int id)
    	{
    		// Actual logic goes here
    	}
    }
