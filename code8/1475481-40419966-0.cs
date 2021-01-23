    ds.TrafficJamMorning = (from row in orderQuery
    						where 
    							DbFunctions.DiffMinutes( DbFunctions.TruncateTime(row.AcceptedTime), row.AcceptedTime) >= 6 * 60 + 30 &&
    							DbFunctions.DiffMinutes( DbFunctions.TruncateTime(row.AcceptedTime), row.AcceptedTime) <= 9 * 60 + 30
    						group row by DbFunctions.TruncateTime(row.AcceptedTime)
    						into grp
    						select new TrafficJamPeriodInfo
    						{
    							CurrentDateTime = grp.Key,
    							ReceptionCount = grp.Count(r => r.OrderOriginId == (int)OrderOrigin.Reception),
    							InternetCount = grp.Count(r => r.OrderOriginId == (int)OrderOrigin.Internet),
    							ExchangeSystemCount = grp.Count(r => r.OrderOriginId == (int)OrderOrigin.ExchangeSystem)
    						}).ToList();
