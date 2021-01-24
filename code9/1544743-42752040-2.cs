    List<dynamic> Details = new List<dynamic>();
 
     foreach (var item in outputStats)
                    {
                       dynamic detail;
                       detail = new ExpandoObject();
                       detail.AirportName  =temp.name;
                       detail.AirportAircraftType  = item.Key;
                       detail.AircraftSeatsSum =item.Sum(p => p.seats);
    
                      Details.Add(detail);
                    }
    
    ViewBag.Details = Details;
