    public ActionResult Edit_ClockGroup(int id, int? readerId = null)
    {
        var vm = readerId.HasValue 
            ?  DAL.GetClockGroupDetail(id, readerId)
            :  DAL.GetClockGroupDetail(id);
    
        return View(vm);            
    }
