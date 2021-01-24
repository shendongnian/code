    public class ThreadWorker
    {
        private ThreadFactory _factory;         // Parent ThreadFactory
        private AutoResetEvent _event = new AutoResetEvent( false );
        private Thread _thread;                 // Worker thread
        private volatile ThreadTask _task;               // Current task
        public ThreadWorker( ThreadFactory parent, string name = null )
        {
            Name = name;
            _factory = parent;
            _thread = new Thread( _Work );
            _thread.Start();
        }
        public string Name { get; }
        ~ThreadWorker()
        {
            _thread?.Abort();                   // If _thread is "valid", _thread.Abort
        }
        private void _Work()
        {
            while ( true )
            {
                _event.WaitOne();
                _task?.Run();                   // If _task is "valid", _task.Run
                // If _factory has more tasks, _task will be set and _lockThread will be false
                // Otherwise the worker thread will lock on the next cycle
                Wake( _factory.Continue( this ) );
            }
        }
        public void Wake( ThreadTask task )
        {
            _task = task;
            if ( _task != null )
            {
                _event.Set();
            }
        }
    }
