     public ActionResult Index()
     {
      var model = new AssetTrackersViewModel();
      model.AssetTrackers.Add(getAssetDetails("ED"));
      model.AssetTrackers.Add(getAssetDetails("EE"));
      return View(model);
     }
