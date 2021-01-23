    var allEvents = GetEventInfos(providerInstance);
    public static EventInfo[] GetEventInfos(IEventProvider eventProvider)
    {
        return eventProvider.GetType().GetEvents();
    }
