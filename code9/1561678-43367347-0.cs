      public ActionResult Index(long? startTime = null, long? endTime = null, string? kpiName = null)
        {
          if(startTime == null || endTime == null || kpiName == null){
            return RedirectToAction("ActionName", "ControllerName");
           }
           // create my viewmodel.
           return View(detailsViewModel);
        }
