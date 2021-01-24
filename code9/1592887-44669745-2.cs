    var activeResults = service.FindAppointments(new FolderId(WellKnownFolderName.Calendar, resource.Email), calendarView).ToList();
    
    service.LoadPropertiesForItems(activeResults, properties);
    
    foreach (Appointment result in activeResults)
    {
    // 1.
    var b = result.ExtendedProperties[1].Value;
    // 2.
    string UCMeetingSetting;
    result.TryGetProperty(extendedUCMeetingSetting, out UCMeetingSetting);
    }
