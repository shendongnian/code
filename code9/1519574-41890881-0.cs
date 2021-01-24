    public static class Utils
    {
        public static void DisableEvents<T>(this T ctrl, string officialName, string simplifiedName) where T : Control
        {
            var propertyInfo = ctrl.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            var eventHandlerList = propertyInfo.GetValue(ctrl, new object[] { }) as EventHandlerList;
            var fieldInfo = typeof(T).GetField(officialName, BindingFlags.NonPublic | BindingFlags.Static);
            var eventKey = fieldInfo.GetValue(ctrl);
            var eventHandler = eventHandlerList[eventKey];
            var invocationList = eventHandler.GetInvocationList();
            foreach (var item in invocationList)
            {
                ctrl.GetType().GetEvent(simplifiedName).RemoveEventHandler(ctrl, item);
            }
        }
    }
