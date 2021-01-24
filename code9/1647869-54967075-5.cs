	public IActionResult Sync()
	{
		Query();
		Query();
		return Ok();
	}
	
	public async Task<IActionResult> Async()
	{
		await QueryAsync();
		await QueryAsync();
		return Ok();
	}
	
	public async Task<IActionResult> Parallel()
	{
		var task1 = QueryAsync();
		var task2 = QueryAsync();
		await task1;
		await task2;
		return Ok();
	}
