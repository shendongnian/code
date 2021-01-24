    public ActionResult Create()
    {
    List<String> AirLinesList = db1.Airlines.ToList();
    var selectListItems = AirLinesList.Select(x => new SelectListItem(){ Value = x, Text = x }).ToList();
    
    return View(selectListItems);
    }
