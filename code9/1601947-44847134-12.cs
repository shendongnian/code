	public IActionResult SomePage()
	{
		var model = new SomeModel()
		{
			SomeProperty = "Your application model property.",
			ControllerActionBlocks = GetControllerBlocks()
		};
		return View(model);
	}
