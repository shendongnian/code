    public ActionResult Settings()
    {
       List<Language> activeL = LanguageController.GetAll();
       
       ViewBag.Languages = activeLanguages.Select(item => new SelectListItem{
    	   Text = item.Name,
    	   Value = item.Id
    	});
    
       return View(activeL);
    }
    @Html.DropDownListFor(m => m.LanguageId, ViewBag.Languages, new { @class = "form-control" })
