    long vehid = json.VehicleId.Value;
    DateTime dateFrom = DateTime.Parse(json.date.Value).Date; // date with no time
    DateTime dateTo = dateFrom.AddDays(1); // add one day to create the date range
    
    var Alerts = (from t2 in entities.Alerts.AsNoTracking()
                  where 
                     t2.GeneratedTimeLocal >= dateFrom 
                  && t2.GeneratedTimeLocal <= dateTo
                  && (t2.AlertType == 2 || t2.AlertType == 3)
                  && t2.vId == vid
                  select new
                  {
                      GeneratedTimeLocal = t2.GeneratedTimeLocal,
                      OptionalText = t2.OptionalText
                  });
    
    return Alerts;
