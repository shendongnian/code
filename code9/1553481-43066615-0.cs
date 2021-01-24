    public ActionResult myController(){
      var model= new myModel();
      return View(model);
    }
    [HttpPost]
    public ActionResult myController(myModel model){
      model.StaffId = 1;
      return View(model);
    }
