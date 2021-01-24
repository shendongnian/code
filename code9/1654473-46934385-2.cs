    [HttpPost]
    public ActionResult getCitiesAction(int provinceId)
    {
        var cities = db.Cities
                       .Where(a => a.RegionId == provinceId)
                       .Select(a => new SelectListItem { Value=a.Id.ToString(), Text=a.Name})
                       .ToList()
        return Json(cities);
    }
