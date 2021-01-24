    List<dynamic> Details = new List<dynamic>();
    dynamic detail;
    
    
     foreach (var item in outputStats)
                    {
                       detail = new ExpandoObject();
                       detail.AirportName  =temp.name;
                       detail.AirportAircraftType  = item.Key;
                       detail.AircraftSeatsSum =item.Sum(p => p.seats);
    
                      Details.Add(detail);
                    }
    
    ViewBag.Details = Details;
