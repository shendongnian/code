    var singleEventWithName = GetEventInfo(providerInstance, nameof(providerInstance.StringAvailable));
    public static EventInfo GetEventInfo(IEventProvider eventProvider, string name)
    {
        var type = eventProvider.GetType();
        return type.GetEvent(name);
    }
