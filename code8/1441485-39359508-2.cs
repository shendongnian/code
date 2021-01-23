    public class InactivityMonitor : IInactivityMonitor
    {
        private readonly ISchedulerProvider _schedulerProvider;
        private readonly IObservable<Unit> _inactivityObservable;
        private static readonly TimeSpan SilencePeriod = TimeSpan.FromSeconds(1);
    public InactivityMonitor(IRaiseActivity activitySource, ISchedulerProvider schedulerProvider)
    {
        _schedulerProvider = schedulerProvider;
        _inactivityObservable = Observable.FromEventPattern<EventHandler<EventArgs>, EventArgs>(
                h => _activitySource.Activity += h,
                h => _activitySource.Activity -= h)
                .StartWith(null)
                .Select(a=>Observable.Timer(TimeSpan.FromSeconds(1), _schedulerProvider.NewThread))
		        .Switch()
		        .Select(_=>Unit.Default)
                .Publish()
                .RefCount();
    }
    //...
}
