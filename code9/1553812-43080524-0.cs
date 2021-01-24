    public class Transition<TEvent>
    {
        public BasicState From { get; set; }
        public BasicState To { get; set; }
        public Func<TEvent, bool> EventMatcher { get; set; }
        ...
    }
