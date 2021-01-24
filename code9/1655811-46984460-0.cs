    public ActionResult Stage()
    {
        var sch = DataRepository.GetSchedules();
        var model = new Stage() 
               {
                 WarehouseSchedule = new SelectList(sch,"ScheduleID","ScheduleName");
               };
        return View(model);
    }
