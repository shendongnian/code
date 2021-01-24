    [HttpPost]
    public ActionResult GetCities(int[] countryIds)
    {    
        var cities = db.Cities
                       .Where(f => countryIds.Contains(f.CountryId))
                       .Select(f => new SelectListItem() { Value = f.Id.ToString(),
                                                           Text = f.Name })
                       .ToList();
    
        return Json(cities);
    
    }
