    public ActionResult Create()
    {
       ViewModel model = new ViewModel();
       model.MyPart = new MyPart ()
                           {
                              ColumnName1 = "Details here",
                              ColumnName2 = 1
                           }
       model.MyAssembly = //populate your Assembly details class
      
       return View(model); //return your view with two classes on one class
    }
