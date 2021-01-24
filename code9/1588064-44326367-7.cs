     public ActionResult Index()
     {
      var model = AssetTrackersViewModel();
      model.AssetTrackers.Add(getAssetDetails("ED"));
      model.AssetTrackers.Add(getAssetDetails("EE"));
      return View(model);
     }
