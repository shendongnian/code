	public ActionResult Index()
	{
		try
		{
			MainAsync().GetAwaiter().GetResult();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.GetBaseException().Message);
		}
		return View();
	}
