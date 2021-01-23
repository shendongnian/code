    scheduler.ForJob<JobWithNoReturn>().Schedule("some_param");
    // using the stuff from #2 and also this
    public static class Extensions 
    {
        ...
        public static void Schedule<TJob, T1>(this IJobScheduler<TJob> job, T1 args)
            where TJob : IJob<T1>
        {
            ...
        }
    }
