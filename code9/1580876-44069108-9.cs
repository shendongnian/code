    public enum EventActionTag
    {
        Add,
        Complete,
        RequestView
    }
    public class EventAction<T>
    {
        public readonly EventActionTag Tag;
        public static EventAction<T> Add(T value) => new AddAction<T>(value);
        public static readonly EventAction<T> RequestView = new RequestViewAction<T>();
        public static readonly EventAction<T> Complete = new CompleteAction<T>();
        public EventAction(EventActionTag tag) =>
            Tag = tag;
    }
    public class AddAction<T> : EventAction<T>
    {
        public readonly T Value;
        public AddAction(T value) : base(EventActionTag.Add) =>
            Value = value;
    }
    public class CompleteAction<T> : EventAction<T>
    {
        public CompleteAction() : base(EventActionTag.Complete)
        { }
    }
    public class RequestViewAction<T> : EventAction<T>
    {
        public RequestViewAction() : base(EventActionTag.RequestView)
        { }
    }
    public class AggregateView<T> : IDisposable
    {
        readonly Subject<EventAction<T>> aggregator = new Subject<EventAction<T>>();
        readonly Subject<T> events = new Subject<T>();
        readonly Subject<Lst<T>> view = new Subject<Lst<T>>();
        readonly IDisposable subscription;
        public AggregateView()
        {
            // Creates an aggregate view of the integers that responds to various control
            // actions coming through.  
            subscription = aggregator.Aggregate(
                Lst<T>.Empty,
                (list, action) =>
                {
                    switch(action.Tag)
                    {
                        // Adds an item to the aggregate list and passes it on to the 
                        // events Subject
                        case EventActionTag.Add:
                            var add = (AddAction<T>)action;
                            events.OnNext(add.Value);
                            return list.Add(add.Value);
                        // Clears the list and passes a list onto the views Subject
                        case EventActionTag.Complete:
                            view.OnNext(Lst<T>.Empty);
                            return Lst<T>.Empty;
                        // Gets the current aggregate list and passes it onto the 
                        // views Subject
                        case EventActionTag.RequestView:
                            view.OnNext(list);
                            return list;
                        default:
                            return list;
                    }
                })
                .Subscribe(x => { });
        }
        /// <summary>
        /// Observable stream of integer events
        /// </summary>
        public IObservable<T> Events => 
            events;
        /// <summary>
        /// Observable stream of list views
        /// </summary>
        public IObservable<Lst<T>> Views =>
            view;
        /// <summary>
        /// Listener for plugging into an event
        /// </summary>
        public void Listener(T value) =>
            aggregator.OnNext(EventAction<T>.Add(value));
        /// <summary>
        /// Clears the aggregate view and post it to Views
        /// </summary>
        public void Complete() =>
            aggregator.OnNext(EventAction<T>.Complete);
        /// <summary>
        /// Requests a the current aggregate view to be pushed through to 
        /// the Views subscribers
        /// </summary>
        public void RequestView() =>
            aggregator.OnNext(EventAction<T>.RequestView);
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() => 
            subscription?.Dispose();
    }
