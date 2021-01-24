    var routeNames = (from n in doc.Descendants(ns + "Service").Descendants(ns + "routes").Descendants(ns + "Route")//.Descendants(ns + "timetables")//.Descendants(ns + "Service")
                              select new RootContainer
                              {
                                  Services = (from s in n.Elements(ns + "timetables").Descendants(ns +"Timetable")
                                                                                  // where n.Elements(ns + "Service") != null
                                              select new Services
    
                                              {
                                                  ServiceName = s.Element(ns + "timetableId").Value,
                                                  //serviceIconUrl = "/Assets/Services/" + s.Element(ns + "serviceName").Value + ".png",
                                                 // ServiceId = s.Element(ns + "serviceId").Value
                                              }).ToList()
                              }).Single();
