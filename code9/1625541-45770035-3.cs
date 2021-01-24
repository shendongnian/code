    var fTime = FTime.TimeOfDay;
    var bTime = FBtime.TimeOfDay;
    
    var Check1 = db.WorkingTs.FirstOrDefault(x => 
    DbFunctions.CreateTime(x.WorkingTime.Hour, x.WorkingTime.Minute, x.WorkingTime.Second) >= fTime  
    || DbFunctions.CreateTime(x.WorkingTime.Hour, x.WorkingTime.Minute, x.WorkingTime.Second) <= bTime 
    && x.FlightsCid == Crewstuff.id);
