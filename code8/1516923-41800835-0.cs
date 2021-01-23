    var countries =new List<Country>(); //assign list of country here.
    ViewBag.AvailableCountries =  countries.Select(x => new SelectListItem
    							   {
    								   Value = x.Id,
    								   Text = x.Name
    							   }).ToList();
