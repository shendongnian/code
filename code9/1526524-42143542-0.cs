	[Route("Edit/{id}", Order = 1)]
	[HttpGet]
	public ActionResult Edit(int id)
	{
		// do stuff
		return View(viewModel);
	}
	[Route("Edit", Order = 2)]
	[HttpPost]
	public ActionResult Edit(DraftViewModel draft)
	{
		if (!ModelState.IsValid) return View(draft);
		// do stuff
		return RedirectToAction("Index");
	}
