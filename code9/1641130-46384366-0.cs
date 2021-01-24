    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        TheObject obj = db.TheObjects.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        Fill_StateDropDownList() 
        FillCities(obj.State);           
        return View(obj);
    }
    private void FillCities(int stateId)
    {
       ViewBag.CityList = db.Cities
                           .Where(g => g.StateId== stateId)
                           .Select(f => new SelectListItem() { 
                                                                Value = f.Id.ToString(), 
                                                                Text = f.Name })
                           .ToList();
    }
