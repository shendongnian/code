    static Dictionary<Event, object> eventMap = new Dictionary<Event, object>() { { Event.MapLocationMarkerClicked, new object() } };
    static EventHandlerList events = new EventHandlerList();
    public static void Subscribe(Event eventToSub, EventListener listener)
    {
        events.AddHandler(eventMap[eventToSub], listener);
    }
    public static void Unsubscribe(Event eventToUnsub, EventListener listener)
    {
        events.RemoveHandler(eventMap[eventToSub], listener);
    }
    public static void Publish(Event eventToPub, object source, EventArgs args)
    {
        EventListener listener = (EventListener)events[eventMap[eventToSub]];
        listener?.Invoke(source, args);
    }
