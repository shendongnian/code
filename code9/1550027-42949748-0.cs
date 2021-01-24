	public async Task<ActionResult> Index()
	{
		try
		{
			await MainAsync().ConfigureAwait(false);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.GetBaseException().Message);
		}
		return View();
	}
	
