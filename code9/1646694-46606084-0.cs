    public ActionResult actionOne(infViewModel pCurrentViewModel)
    {
       infViewModel _CurrentViewModel = new infViewModel();
       _CurrentViewModel = pCurrentViewModel;
    
       infElement _Element = new infElement();
       _Element.ViewModel = _CurrentViewModel;
       TempData["_Element"] = _Element;
    
       return RedirectToAction("actionTwo");
    }
    
    public ActionResult actionTwo()
    {
        var _Element = TempData["_Element"] as infElement;
        // ...
    }
