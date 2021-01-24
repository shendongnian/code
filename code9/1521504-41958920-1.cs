    XDocument doc = XDocument.Load("timetableTest.xml");
        XNamespace ns = "http://schemas.datacontract.org/2004/07/BusExpress.ClassLibrary";
        var routeNames = (from n in doc.Descendants(ns + "Service").Descendants(ns + "routes").Descendants(ns + "Route")//.Descendants(ns + "timetables")//.Descendants(ns + "Service")
                          select new 
                          {
                              Services = (from s in n.Elements(ns + "timetables")//.Elements(ns + "clients")
                                          from t in s.Descendants(ns + "Timetable")                              // where n.Elements(ns + "Service") != null
                                          select new 
                                          {
                                              ServiceName = t.Element(ns + "timetableId").Value,
                                              //serviceIconUrl = "/Assets/Services/" + s.Element(ns + "serviceName").Value + ".png",
                                             // ServiceId = s.Element(ns + "serviceId").Value
                                          }).ToList()
                          }).Single();
        listServices.ItemsSource = routeNames.Services;
