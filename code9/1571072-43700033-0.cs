	[HttpGet]
	public ActionResult Index()
	{
		ViewBag.List = new Dictionary<string, string[]>
		{
			{ "Premier League", new[] { "Arsenal", "Chelsea" } },
			{ "Bundesliga",     new[] { "Bayern Munchen", "Wolfsburg" } },
		};
		
		return View();
	}
