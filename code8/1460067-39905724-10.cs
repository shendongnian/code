    public class ActionRetryConfiguration : IRetryConfiguration
    {
        private readonly Action _action;
        private readonly int? _times;
        private readonly TimeSpan? _interval;
        public ActionRetryConfiguration(Action action, int? times, TimeSpan? interval)
        {
            _action = action;
            _times = times;
            _interval = interval;
        }
        public void Execute()
        {
            Execute(_action, _times, _interval);
        }
        private void Execute(Action action, int? times, TimeSpan? interval)
        {
            action();
            if (times.HasValue && times.Value <= 1) return;
            if (times.HasValue && interval.HasValue) Thread.Sleep(interval.Value);
            Execute(action, times - 1, interval);
        }
        public IRetryConfiguration Times(int repetitions)
        {
            return new ActionRetryConfiguration(_action, repetitions, _interval);
        }
        public IRetryConfiguration Interval(TimeSpan interval)
        {
            return new ActionRetryConfiguration(_action, _times, interval);
        }
    }
    public class FunctionRetryConfiguration<TResult> : IRetryConfiguration<TResult>
    {
        private readonly Func<TResult> _function;
        private readonly int? _times;
        private readonly TimeSpan? _interval;
        private readonly Func<TResult, bool> _condition;
        public FunctionRetryConfiguration(Func<TResult> function, int? times, TimeSpan? interval, Func<TResult, bool> condition)
        {
            _function = function;
            _times = times;
            _interval = interval;
            _condition = condition;
        }
        public TResult Execute()
        {
            return Execute(_function, _times, _interval, _condition);
        }
        private TResult Execute(Func<TResult> function, int? times, TimeSpan? interval, Func<TResult, bool> condition)
        {
            TResult result = function();
            if (condition != null && condition(result)) return result;
            if (times.HasValue && times.Value <= 1) return result;
            if ((times.HasValue || condition != null) && interval.HasValue) Thread.Sleep(interval.Value);
            return Execute(function, times - 1, interval, condition);
        }
        public IRetryConfiguration<TResult> Times(int repetitions)
        {
            return new FunctionRetryConfiguration<TResult>(_function, repetitions, _interval, _condition);
        }
        public IRetryConfiguration<TResult> Interval(TimeSpan interval)
        {
            return new FunctionRetryConfiguration<TResult>(_function, _times, interval, _condition);
        }
        public IRetryConfiguration<TResult> Until(Func<TResult, bool> condition)
        {
            return new FunctionRetryConfiguration<TResult>(_function, _times, _interval, condition);
        }
    }
