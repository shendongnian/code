    public ActionResult EditRecord(string id, bool createNew = false)
    {
        id = id ?? TempData["id"];
    
        //your code
    }
    
    
    [HttpPost]
    public ActionResult EditProductAlias(MyRecordViewModel viewModel)
    {
        //your code
    
        TempData[id] = viewModel.Id;
    
        return RedirectToAction("EditRecord", "ControllerName")
    }
