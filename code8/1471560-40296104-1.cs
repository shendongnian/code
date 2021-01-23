    public ActionResult Countriesdata()
    {
        CountrydetailsViewModel vm = new CountrydetailsViewModel();
        ConfigureViewModel(vm);
        return View(vm);
    }
    [HttpPost]
    public ActionResult Countriesdata(CountrydetailsViewModel returnmodel)
    {
        if(!ModelState.IsValid)
        {
            ConfigureViewModel(returnmodel);
            return View(returnmodel); 
        }
        .... // save and redirect
    }
    private ConfigureViewModel(CountrydetailsViewModel model)
    {
        var countries = dal.countries();
        model.CountryList= countries.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.CountryID.ToString() 
        });
        if (model.SelectedCountry.HasValue)
        {
            // adjust query to suit your property names
            var towns = db.towns.Where(e => e.CountryId == model.SelectedCountry);
            model.TownList = towns.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.TownID.ToString()   
            });
        }
        else
        {
            model.TownList = new SelectList(Enumerable.Empty<SelectListItem>());
        }
    }
