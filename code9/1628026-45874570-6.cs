    public ActionResult actionC (ViewModel_Shared modelA)
    {
            var modelC = TempData["shared_model"];
            modelC.FillEditedData();
            
            ViewBag.Model = modelC;
            return View();
    }
