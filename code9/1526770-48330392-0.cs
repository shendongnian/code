    try
    {
        service.Events.Insert(newEvent, calendarId).Execute();
    }
    catch (Exception)
    {
        service.Events.Update(newEvent, calendarId, newEvent.Id).Execute();
    }
