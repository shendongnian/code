    var eventInfo = GetEventInfo(nameof(providerInstance.StringAvailable));
    public static EventInfo GetEventInfo(string name)
    {
        return typeof(IEventProvider).GetEvent(name);
    }
