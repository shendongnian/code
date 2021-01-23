    static class EventHelper {
        public static void Subscribe<TSource, TEventArgs>(TSource source, Expression<Func<TSource, EventHandler<TEventArgs>>> eventRef, EventHandler<TEventArgs> handler) where TEventArgs : EventArgs {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            var memberExp = eventRef.Body as MemberExpression;
            if (memberExp == null)
                throw new ArgumentException("eventRef should be member access expression");
            
            var eventName = memberExp.Member.Name;
        #if WeakEvents
            WeakEventManager<TSource, TEventArgs>.AddHandler(source, eventName, handler);            
        #else
            // some reflection here to get to the event
            var ev = source.GetType().GetEvent(eventName);
            if (ev == null)
                throw new ArgumentException($"There is no event with name {eventName} on type {source.GetType()}");
            ev.AddMethod.Invoke(source, new object[] { handler });
        #endif
        }
    }
