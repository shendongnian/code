    InsightsClient client = new InsightsClient(credentials);
    DateTime endDateTime = DateTime.Now;
    DateTime startDateTime = endDateTime.AddDays(days);
    string filterString = FilterString.Generate<ListEventsForResourceProviderParameters>(eventData => (eventData.EventTimestamp >= startDateTime) && (eventData.EventTimestamp <= endDateTime) && (eventData.ResourceType == "Microsoft.Network/connections"));
    EventDataListResponse response = client.EventOperations.ListEvents(filterString, selectedProperties: null);
    List<EventData> logList = new List<EventData>(response.EventDataCollection.Value);
    while (!string.IsNullOrEmpty(response.EventDataCollection.NextLink))
    {
        response = client.EventOperations.ListEventsNext(response.EventDataCollection.NextLink);
        logList.AddRange(response.EventDataCollection.Value);
    }
