    static class EventHelper {
        public static void Subscribe<TSource, TEventArgs>(TSource source, Expression<Func<TSource, EventHandler<TEventArgs>>> eventRef, EventHandler<TEventArgs> handler) where TEventArgs : EventArgs {
            // first obtain event name from expression
            var eventName = ((MemberExpression)eventRef.Body).Member.Name;
        #if WeakEvents
            WeakEventManager<TSource, TEventArgs>.AddHandler(source, eventName, handler);
        #else
            // some reflection here to get to the event
            source.GetType().GetEvent(eventName).AddMethod.Invoke(source, new object[] { handler });
        #endif
        }
    }
