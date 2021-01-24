    public ActionResult Edit(){
    
    ....retrieve Model
    
    return View(MyModel); // default view : Edit
    
    }
    
    [HttpPost]
    
    public ActionResult Edit(MyModel){
    
    ....do things with MyModel
    
    return View("OtherView", MyModel);
    
    }
