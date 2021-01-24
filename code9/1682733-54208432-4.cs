	[Authorize("GenerateLetterAdUser")]
	[HttpGet]
	public IActionResult Generate()
	{
		return View();
	}
