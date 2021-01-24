    [HttpGet]
    public ActionResult StudentSearch(SearchModel model)
    {
        if (model.Date1 == null || model.Date2 == null)
        {
            model.Date1 = DateTime.Now;
            model.Date2 = DateTime.Now;
        }
    
        return View(model); <---
                    ^^^^^
    }
