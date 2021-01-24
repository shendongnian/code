    public ActionResult SubmitForm(YourFormModel model)
    {
        if (ModelState.IsValid) {
        	var submitResults = ResultsOfYourCode();
    	    ViewData["submitResults"] = submitResults;
    	    return RedirectToCurrentUmbracoPage();
        }
    }
