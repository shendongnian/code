	[HttpPost]
    public ActionResult UserInput(UserInputViewModel inputParameters)
    {
		if (!ModelState.IsValid)
		{
			return View();
		}
		return RedirectToAction("Play", "Home" , new RouteValueDictionary(inputParameters));
	}
 
