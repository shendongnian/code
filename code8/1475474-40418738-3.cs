    var startTime = new TimeSpan(6, 30, 0);
    var endTime = new TimeSpan(9, 30, 0);
    var result = (from row in orderQuery
                  let time = EntityFunctions.CreateTime(row.AcceptedTime.Hour, row.AcceptedTime.Minute, row.AcceptedTime.Second)
                  where time  >= startTime &&
                        time  <= endTime
                  group row by row.AcceptedTime.Date into grp
                  select new TrafficJamPeriodInfo
                  {
                       CurrentDateTime = grp.Key,
                       ReceptionCount = grp.Count(r => r.OrderOriginId == (int)OrderOrigin.Reception),
                       InternetCount = grp.Count(r => r.OrderOriginId == (int)OrderOrigin.Internet),
                       ExchangeSystemCount = grp.Count(r => r.OrderOriginId == (int)OrderOrigin.ExchangeSystem)
                  }).ToList();
