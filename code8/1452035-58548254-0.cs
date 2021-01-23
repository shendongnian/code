    public static class EventExtensions
    {
        public static void ClearEventHandlers(this object obj, string eventName)
        {
            if (obj == null)
            {
                return;
            }
            var objType = obj.GetType();
            var eventInfo = objType.GetEvent(eventName);
            if (eventInfo == null)
            {
                return;
            }
            var isEventProperty = false;
            var type = objType;
            FieldInfo eventFieldInfo = null;
            while (type != null)
            {
                /* Find events defined as field */
                eventFieldInfo = type.GetField(eventName, BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (eventFieldInfo != null && (eventFieldInfo.FieldType == typeof(MulticastDelegate) || eventFieldInfo.FieldType.IsSubclassOf(typeof(MulticastDelegate))))
                {
                    break;
                }
                /* Find events defined as property { add; remove; } */
                eventFieldInfo = type.GetField("EVENT_" + eventName.ToUpper(), BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
                if (eventFieldInfo != null)
                {
                    isEventProperty = true;
                    break;
                }
                type = type.BaseType;
            }
            if (eventFieldInfo == null)
            {
                return;
            }
            if (isEventProperty)
            {
                // Default Events Collection Type
                RemoveHandler<EventHandlerList>(obj, eventFieldInfo);
                // Infragistics Events Collection Type
                RemoveHandler<EventHandlerDictionary>(obj, eventFieldInfo);
                return;
            }
            if (!(eventFieldInfo.GetValue(obj) is Delegate eventDelegate))
            {
                return;
            }
            
            // Remove Field based event handlers
            foreach (var d in eventDelegate.GetInvocationList())
            {
                eventInfo.RemoveEventHandler(obj, d);
            }
        }
        private static void RemoveHandler<T>(object obj, FieldInfo eventFieldInfo)
        {
            var objType = obj.GetType();
            var eventPropertyValue = eventFieldInfo.GetValue(obj);
            if (eventPropertyValue == null)
            {
                return;
            }
            var propertyInfo = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                                      .FirstOrDefault(p => p.Name == "Events" && p.PropertyType == typeof(T));
            if (propertyInfo == null)
            {
                return;
            }
            var eventList = propertyInfo?.GetValue(obj, null);
            switch (eventList) {
                case null:
                    return;
                case EventHandlerDictionary typedEventList:
                    typedEventList.RemoveHandler(eventPropertyValue, typedEventList[eventPropertyValue]);
                    break;
            }
        }
    }
