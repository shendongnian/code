    public ActionResult GetStates(int countryId)
    {
        var t=db.States.Where(f => f.CountryId == countryId)
            .Select(f => new SelectListItem() { Value = f.Id.ToString(), 
                                                Text = f.Name})
            .ToList();
        return Json(t, JsonRequestBehavior.AllowGet);
    }
