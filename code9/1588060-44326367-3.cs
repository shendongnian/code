     public ActionResult Index()
     {
      var model = AssetTrackerViewModel();
      model.AssetTrackers.Add(getAssetDetails("ED"));
      model.AssetTrackers.Add(getAssetDetails("EE"));
      return View(model);
     }
