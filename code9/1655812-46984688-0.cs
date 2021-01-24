    public ActionResult Stage()
    {
        var model = new Stage() 
        {
            WarehouseSchedule = DataRepository.GetSchedules()
                                             .Select(x=>new SelectListItem {
                                                              Value=x.Id.ToString(), 
                                                              Text=x.Name })
                                             .ToList();
        };
        return View(model);
    }
