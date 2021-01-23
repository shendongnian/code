    var singleEvent = GetEventInfo(providerInstance);
    
    public static EventInfo GetEventInfo(IEventProvider eventProvider)
    {
        var type = eventProvider.GetType();
        return type.GetEvent(nameof(eventProvider.StringAvailable));
    }
