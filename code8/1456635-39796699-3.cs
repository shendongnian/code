        public JobTask Do(int input)
        {
            var job = new JobTask(input);
            _workQueue.Add(job);
            return job;
        }
    public class JobTask
    {
        private readonly int _input;
        private readonly TaskCompletionSource<bool> _completionSource;
        public JobTask(int input)
        {
            _input = input;
            _completionSource = new TaskCompletionSource<bool>();
        }
        public void PerformWork()
        {
            try
            {
                // Do stuff here with _input.
                _completionSource.TrySetResult(true);
            }
            catch(Exception ex)
            {
                _completionSource.TrySetException(ex);
            }
        }
        public Task<bool> Work { get { return _completionSource.Task; } }
    }
