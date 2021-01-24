    [HttpGet]
    public ActionResult Edit(int? id)
    {
       return View();
    }
    [HttpPost]
    public ActionResult Edit(Object myObject)
    {
      return View();
    }
.
    var controller = new Controller();
    controller.Edit(myObject: null);
    controller.Edit(id: null);
