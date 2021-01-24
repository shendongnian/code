    // The first thing we need to do is delete the existing events
    if(oData.Settings.CalendarEntryType == "CLM_MidweekMeeting")
    {
    	// We only want events within the desired date range
    	string strFilterDateRange = String.Format(
    		"start/dateTime ge '{0}T00:00' and end/dateTime le '{1}T23:59'",
    		oData.Settings.StartDate.ToString("yyyy-MM-dd"),
    		oData.Settings.EndDate.ToString("yyyy-MM-dd"));
    
    	// We only want events of the right type
    	string strFilterProperty = $"singleValueExtendedProperties/Any(ep: ep/id eq '{_PropertyCLM_MidweekMeeting}' and ep/value eq 'CLM_MidweekMeeting')";
    
    	string strFilter = strFilterDateRange + " and " + strFilterProperty;
    
    	// Select the events (if any) and delete them
    	var oEvents = await _graphClient
    						 .Me
    						 .Calendars[oData.Settings.CalendarID]
    						 .Events
    						 .Request()
    						 .Filter(strFilter)
    						 .GetAsync();
    	if (oEvents?.Count > 0)
    	{
    		foreach (Event oEvent in oEvents)
    		{
    			// Delete the event (Do I need to use the specific calendar events list?)
    			await _graphClient.Me.Events[oEvent.Id].Request().DeleteAsync();
    		}
    	}
    }
