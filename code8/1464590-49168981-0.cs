    public sealed class SchedulerProvider : ISchedulerProvider
        {
            public IScheduler Foreground => new SynchronizationContextScheduler(SynchronizationContext.Current);
            public IScheduler Background => TaskPoolScheduler.Default;
        }
