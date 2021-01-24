    public abstract class TransitionBase<TEvent>
        where TEvent : IEquatable<TEvent>
    {
        public BasicState From { get; set; }
        public BasicState To { get; set; }
        public abstract bool DoesMatchEvent(TEvent event);
    }
    public class SingleEventTransition<TEvent> : TransitionBase<TEvent>
        where TEvent : IEquatable<TEvent>
    {
        TEvent Event { get; set; }
        public override bool DoesMatchEvent(TEvent event)
        {
            return Event.Equals(event);
        }
    }
    public class MultiEventTransition<TEvent> : TransitionBase<TEvent>
        where TEvent : IEquatable<TEvent>
    {
        TEvent[] Events { get; set; }
        public override bool DoesMatchEvent(TEvent event)
        {
            foreach (TEvent e in Events) {
                if (e.Equals(event)) {
                    return true;
                }
            }
            return false;
        }
    }
