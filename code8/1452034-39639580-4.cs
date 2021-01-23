    public static Delegate AddEventHandler(EventInfo eventInfo, object item, Action action)
    {
        var parameters = GetParameters(eventInfo);
        var handler = GetHandler(eventInfo, action, parameters);
        eventInfo.AddEventHandler(item, handler);
        return handler;
    }
    public static void RemoveEventHandler(EventInfo eventInfo,
                        object item, Delegate handler)
    {
        eventInfo.RemoveEventHandler(item, handler);
    }
---
    var handler = EventSubscriber.AddEventHandler(eventInfo, timer, TimerElapsed);
    EventSubscriber.RemoveEventHandler(eventInfo, timer, handler);
