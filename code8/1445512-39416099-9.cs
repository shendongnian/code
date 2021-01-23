    var trackingQuery = dbContext.PackageAppointments.ToString();
    
    Console.WriteLine("==========================");
    Console.WriteLine("Query with Change Tracker enabled");
    Console.WriteLine(trackingQuery);
    Console.WriteLine("==========================");
    Console.WriteLine("\n\n");
    
    var noTrackingQuery = dbContext.PackageAppointments.AsNoTracking().ToString();
    
    Console.WriteLine("==========================");
    Console.WriteLine("Query with Change Tracker disabled");
    Console.WriteLine(noTrackingQuery);
    Console.WriteLine("==========================");
