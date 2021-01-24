    public ActionResult GetSliderValues(string dvalue)
    {
        ProviderName p = new ProviderName();
        p.Name = dvalue;
        return View(p);   
    }
