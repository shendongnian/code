    public ActionResult Register(RegisterViewModel rvm)
    {
        var selectedCountry = rvm.SelectedCountry;
        //to do : Reload Countries property of rvm again here(same as your GET action)
    
        return View(rvm);
    }
