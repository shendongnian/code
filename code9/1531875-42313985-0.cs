        public class MyEventAggregator
        {
            private static List<Tuple<CoreDispatcher, object>> subscribers = new List<Tuple<CoreDispatcher, object>>();
            public void Subscribe<TMessage>(ISubscriber<TMessage> subscriber)
            {
                subscribers.Add(new Tuple<CoreDispatcher,object>(Window.Current.Dispatcher, subscriber));
            }
