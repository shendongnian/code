    int result = scheduler.ForJob<SomeJob>.Schedule("some_param");
    // using this
    public interface IScheduler
    {
        IJobScheduler<TJob> ForJob<TJob>();
    }
    public interface IJobScheduler<out TJob> { }
    
    public static class Extensions 
    {
        public static T2 Schedule<T1, T2>(this IJobScheduler<IJob<T1, T2>> job, T1 args)
        {
            ...
        }
    }
