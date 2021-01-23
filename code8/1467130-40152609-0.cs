    public ActionResult MyAction()
    {
       var myModel = new MyModel() {Email = Session['UserEmail'].ToString();}
       return View(myModel);
    }
