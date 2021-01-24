    public class TimeMeasurerResult
    {
        protected readonly Task _task;
        private readonly TimeSpan _duration;
    
        public TimeMeasurerResult(Task task, TimeSpan duration)
        {
            _task = task;
            _duration = duration;
        }
    
        public Task Task {get { return _task;}}
        public TimeSpan Duration {get {return _duration;}}
    }
    public class TimeMeasurerResult<T> : TimeMeasurerResult
    {    
        public TimeMeasurerResult(Task<T> task, TimeSpan duration)
            :base(task, duration)
        {
        }
    
        //Intentionally shadowing the base class'es Task property.
        public new Task<T> Task {get { return (Task<T>)_task;}}
    }
    
    public static class TimeMeasurer 
    {    
        public static async Task<TimeMeasurerResult<TReturn>> Start<TReturn>(Func<Task<TReturn>> function)
        {
            var stopWatch = Stopwatch.StartNew();
            var task = function();
            await task;
            var took = stopWatch.Elapsed;
    
            return new TimeMeasurerResult<TReturn>(task, took);
        }
        
        public static async Task<TimeMeasurerResult> Start(Func<Task> function)
        {
            var stopWatch = Stopwatch.StartNew();
            var task = function();
            await task;
            var took = stopWatch.Elapsed;
    
            return new TimeMeasurerResult(task, took);
        }    
    }
