	public IActionResult LoadVisit(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		var model = new VisitViewModel();
		try
		{
			model = await visitAPI.GetVisit(clientID, visitID);
		}
		catch (Exception ex)
		{
			return Content(ex.Message);
		}
		return ViewComponent("ClientVisit", model });
	}
