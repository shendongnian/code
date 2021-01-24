     public ActionResult CitySelectList(int? stateId)
        {
            LocationCreateViewModel locationCreateViewModel = new LocationCreateViewModel();
            locationCreateViewModel.CitySelectListViewModel = new CitySelectListViewModel(db.Cities.Where(c => c.StateId == stateId).ToList());
            return View(locationCreateViewModel);
        }
