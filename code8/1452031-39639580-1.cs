    public static void RemoveEventHandler(EventInfo eventInfo,
                        object item, Action action)
    {
        var parameters = GetParameters(eventInfo);
        var handler = GetHandler(eventInfo, action, parameters); // <--
        eventInfo.RemoveEventHandler(item, handler);
    }
