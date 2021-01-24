	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> GetStatesJson(
	   string countryCode)
	{
		var country = await dataManager.FetchCountry(countryCode);
		List<IGeoZone> states;
		if (country != null)
		{
			states = await dataManager.GetGeoZonesByCountry(country.Id);
		}
		else
		{
			states = new List<IGeoZone>(); //empty list
		}
		var selecteList = new SelectList(states, "Code", "Name");
		return Json(selecteList);
	}
