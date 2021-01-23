    public ActionResult QuoteEdit()
    {
        var model = new QuoteEdit_ViewModel();
        
        PopulateQuoteEditViewModel(model);
        return View(model);
    }
    [HttpPost]
    public ActionResult QuoteEdit(QuoteEdit_ViewModel model)
    {
        if (ModelState.IsValid)
        {
            ...
        }
        PopulateQuoteEditViewModel(model);
        return View(model);
    }
