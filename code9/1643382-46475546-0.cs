    [HttpPost]
    public ActionResult Create(Reservation _data)
    {
      //do validation ...
      //now send the data to Confirm action to show the view that user can confirm. Pass the data along.
      return RedirectToAction("Confirm", "[Controller]", new {@_data = _data});
    }
    [HttpGet]
    public ActionResult Confirm(Reservation _data)
    {
      return View(_data) //no need to use a different model in your verification page. Just don't make the Html fields editable. 
    }
    [HttpPost]
    public ActionResult Confirm(Reservation _data)
    {
      //save 
    }
