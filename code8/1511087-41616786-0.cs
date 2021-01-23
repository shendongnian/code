    var certificate = new X509Certificate2("myp12filepath", "notasecret", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
    
    ServiceAccountCredential credential = new ServiceAccountCredential(
    	new ServiceAccountCredential.Initializer(serviceAccountEmail)
    	{
    		Scopes = Scopes
    	}.FromCertificate(certificate));
    
    BaseClientService.Initializer initializer = new BaseClientService.Initializer();
    initializer.HttpClientInitializer = credential;
    initializer.ApplicationName = ApplicationName;
    var service1 = new CalendarService(initializer);
    
    EventsResource.DeleteRequest delReq = service1.Events.Delete("calendarId", "eventId");
    delReq.SendNotifications = true;
    var googleCalendarEvent = delReq.Execute();
