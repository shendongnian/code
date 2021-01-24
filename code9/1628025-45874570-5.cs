    public ActionResult actionA (ViewModel_Shared modelA)
    {
            TempData["shared_model"] = modelA;
            return RedirectToAction("actionC", "controllerC");
    }
    
