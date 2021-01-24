    [HttpPost]
    public ActionResult SubmitForm(FormModel model)
    {
        if (ModelState.IsValid)
        {
            // other stuff
        }
    
        List<SelectListItem> year = new List<SelectListItem>();
    
        for (var i = 1990; i <= DateTime.Now.Year; i++)
        {
            year.Add(new SelectListItem
            {
                Text = i.ToString(),
                Value = i.ToString(),
                Selected = false
            });
        }
    
        ViewBag.Year = year; // this line repopulates ViewBag when submit failed
        return View(model);
    }
