	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult DoSomething(Something obj)
	{
		// Use web service to get the string URL
		string urlString = ...;
		if (string.IsNullOrEmpty(urlString))
		{
			// If the urlString is empty, take the user to an Error View.
			return View("Error");        
		}
        // Redirect the user to the urlString
		return Redirect(urlString);
	}
