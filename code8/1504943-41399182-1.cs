    var qryRecords = from rec in dbContext.Records
               .Include(rec => c.Action)
               .Include(rec => c.Equipment)
               .Include(rec => c.Location)
               .Include(rec => c.User)
               .Where(rec => rec.RecordDate >= StartDate && rec.RecordDate <= EndDate) //it needs manages string date comparing with close attention, better it would be if dates were DateTime...
    bool userFilter = (UserID == "") ? false : true;
    bool locationFilter = (LocationID == "") ? false : true;
    bool equipmentFilter = (EquipmentID == "") ? false : true;
    var filterdQuery = from rec in qryRecords
                       where (userFilter ? rec.UserID == UserID : 1 == 1)
                          && (locationFilter ? rec.LocationID == LocationID : 1 == 1)
                          && (equipmentFilter ? rec.EquipmentID == EquipmentID : 1 == 1);
    vm.FilteredRecords = records.ToList();
