    var model = new CompanyInfoViewModel();
	
	model.CompanyRegion = selectedSite.CompanyRegion;
	model.CompanyCountry = selectedSite.CompanyCountry;
	
	model.AvailableCountries.Add(new SelectListItem { Text = sr["-Please select-"], Value = "" });
	var countries = await geoDataManager.GetAllCountries();
	var selectedCountryGuid = Guid.Empty;
	foreach (var country in countries)
	{
		if (country.ISOCode2 == model.CompanyCountry)
		{
			selectedCountryGuid = country.Id;
		}
		model.AvailableCountries.Add(new SelectListItem()
		{
			Text = country.Name,
			Value = country.ISOCode2.ToString()
		});
	}
	if (selectedCountryGuid != Guid.Empty)
	{
		var states = await geoDataManager.GetGeoZonesByCountry(selectedCountryGuid);
		foreach (var state in states)
		{
			model.AvailableStates.Add(new SelectListItem()
			{
				Text = state.Name,
				Value = state.Code
			});
		}
	}
