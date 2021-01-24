    using System;
    using LanguageExt;
    using static LanguageExt.Prelude;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    public class AggregateView : IDisposable
    {
        readonly Subject<EventAction> aggregator = new Subject<EventAction>();
        readonly Subject<int> events = new Subject<int>();
        readonly Subject<Lst<int>> view = new Subject<Lst<int>>();
        readonly IDisposable subscription;
        public AggregateView()
        {
            // Creates an aggregate view of the integers that responds to various control
            // actions coming through.  
            subscription = aggregator.Aggregate(
                Lst<int>.Empty,
                (list, action) =>
                {
                    switch(action)
                    {
                        // Adds an item to the aggregate list and passes it on to the 
                        // events Subject
                        case AddAction add:
                            events.OnNext(add.Value);
                            return list.Add(add.Value);
                        // Clears the list and passes a list onto the views Subject
                        case CompleteAction complete:
                            view.OnNext(Lst<int>.Empty);
                            return Lst<int>.Empty;
                        // Gets the current aggregate list and passes it onto the 
                        // views Subject
                        case RequestViewAction req:
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
        public IObservable<int> Events => 
            events;
        /// <summary>
        /// Observable stream of list views
        /// </summary>
        public IObservable<Lst<int>> Views =>
            view;
        /// <summary>
        /// Listener for plugging into an event
        /// </summary>
        public void Listener(int value) =>
            aggregator.OnNext(EventAction.Add(value));
        /// <summary>
        /// Clears the aggregate view and post it to Views
        /// </summary>
        public void Complete() =>
            aggregator.OnNext(EventAction.Complete);
        /// <summary>
        /// Requests a the current aggregate view to be pushed through to 
        /// the Views subscribers
        /// </summary>
        public void RequestView() =>
            aggregator.OnNext(EventAction.RequestView);
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() => 
            subscription?.Dispose();
    }
