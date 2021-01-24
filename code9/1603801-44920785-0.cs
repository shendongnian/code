    [HttpPost]
    public ActionResult SubmitForm(ViewModel model)
    {
        // other stuff   
        
        // parse every textarea lines as list elements
        List<string> list = model.TextAreaModel.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        // assign it to other list property on other model
        OtherModel.OtherList = list;
    
        // other stuff
    
        return View(model);
    }
