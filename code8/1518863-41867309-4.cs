    public ActionResult Create()
    {
        RespondentVM model = new RespondentVM();
        ConfigureViewModel(model);
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(RespondentVM model) // note a [Bind]` attribute is not required
    {
        if (!ModelState.IsValid)
        {
            ConfigureViewModel(model);
            return View(model);
        }
        // Initialize an instance of your data model and set its properties based on the view model
        TRRESPONDENT respondent = new TRRESPONDENT()
        {
            FULL_NAME = model.FullName,
            CITY_ID = model.CityID,
            ....
            // Set default values
            ENTRY_DATE = DateTime.Now,
            ....
        }
        db.TRRESPONDENTs.Add(respondent);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    // Common code for populating SelectLists etc - DRY!
    private void ConfigureviewModel(RespondentVM model)
    {
        // Note - delete the 4th parameter of the SelectList constructor
        model.CityID = new SelectList(db.LTCITies, "CITY_ID", "CITY_NAME");
    }
