    internal sealed class ReactiveCrossConnectivity : IConnectivity
    {
        public IObservable<bool> IsConnected { get; }
        public ReactiveCrossConnectivity(
            Plugin.Connectivity.Abstractions.IConnectivity connectivity, 
            ISchedulerProvider scheduler)
        {
            IsConnected = Observable
                .FromEventPattern<ConnectivityChangedEventHandler, ConnectivityChangedEventArgs>(
                    handler => connectivity.ConnectivityChanged += handler,
                    handler => connectivity.ConnectivityChanged -= handler,
                    scheduler.Defaults.ConstantTimeOperations)
                .Select(args => args.EventArgs.IsConnected)
                .Throttle(isConnected => isConnected
                    ? Observable.Timer(TimeSpan.FromMilliseconds(250),
                          scheduler.Defaults.TimeBasedOperations)
                    : Observable.Return<long>(0))
                .StartWith(scheduler.Defaults.ConstantTimeOperations, connectivity.IsConnected)
                .DistinctUntilChanged()
                .Replay(1, scheduler.Defaults.Iteration)
                .RefCount();
        }
    }
