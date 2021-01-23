    public ActionResult AddDropdown()
    {
        Model.Institute Result = new Model.Institute()
        //you can generate your Model.Institue in here
        
        Return PartialView("Institute", Result); //this will render Result with Institute.cshtml
    }
