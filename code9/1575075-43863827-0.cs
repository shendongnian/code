    class Example
    {
        internal static readonly Subject<Unit> EventStreamSubject =
            new Subject<Unit>();
        private static readonly Subject<Unit> ExternalEventStreamSubject =
            new Subject<Unit>();
        private static bool _isConnected = false;
        private static void Connect()
        {
            if (!_isConnected)
            {
                EventStreamSubject.Subscribe(ExternalEventStreamSubject);
                _isConnected = true;
            }
        }
        public static IObservable<Unit> EventStream
        {
            get
            {
                Connect();
                return ExternalEventStreamSubject.AsObservable();
            }
        }
        public static void SetDefault(IObserver<Unit> defaultSubscriber)
        {
            if (!Object.ReferenceEquals(_defaultSubscriber, defaultSubscriber))
            {
                _defaultSubscription?.Dispose();
                _defaultSubscriber = defaultSubscriber;
                if (_defaultSubscriber != null)
                {
                    _defaultSubscription = EventStreamSubject.
                        Where(x => !ExternalEventStreamSubject.HasObservers).
                        Subscribe(_defaultSubscriber);
                }
            }
        }
        private static IObserver<Unit> _defaultSubscriber;
        private static IDisposable _defaultSubscription;
    }
