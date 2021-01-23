    var records = dbContext.Record.Where(p => p.RecordDate >= StartDate && p.RecordDate <= EndDate);
    if(!string.IsNullOrEmpty(UserID)){
        records.Where(p => p.UserID = UserID);
    }
    if(!string.IsNullOrEmpty(LocationID)){
        records.Where(p => p.LocationID = LocationID);
    }
    if(!string.IsNullOrEmpty(EquipmentID)){
        records.Where(p => p.EquipmentID = EquipmentID);
    }
    var vm = vm = new GeneratedReportViewModel{
        FilteredRecords = records
    };
    return View("GeneratedReport", vm);
