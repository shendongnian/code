    public class PriorityScheduler : TaskScheduler
    {
        public static PriorityScheduler Highest = new PriorityScheduler(ThreadPriority.Highest);
        //public static PriorityScheduler AboveNormal = new PriorityScheduler(ThreadPriority.AboveNormal);
        //public static PriorityScheduler BelowNormal = new PriorityScheduler(ThreadPriority.BelowNormal);
        //public static PriorityScheduler Lowest = new PriorityScheduler(ThreadPriority.Lowest);
        private BlockingCollection<Task> _tasks = new BlockingCollection<Task>();
        private Thread[] _threads;
        private ThreadPriority _priority;
        private readonly int _maximumConcurrencyLevel = 2;//Math.Max(1, Environment.ProcessorCount);
        public PriorityScheduler(ThreadPriority priority)
        {
            _priority = priority;
        }
        public override int MaximumConcurrencyLevel
        {
            get { return _maximumConcurrencyLevel; }
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks;
        }
        protected override void QueueTask(Task task)
        {
            _tasks.Add(task);
            if (_threads == null)
            {
                _threads = new Thread[_maximumConcurrencyLevel];
                for (int i = 0; i < _threads.Length; i++)
                {
                    int local = i;
                    _threads[i] = new Thread(() =>
                    {
                        foreach (Task t in _tasks.GetConsumingEnumerable())
                            base.TryExecuteTask(t);
                    });
                    _threads[i].Name = string.Format("PriorityScheduler: ", i);
                    _threads[i].Priority = _priority;
                    _threads[i].IsBackground = false;
                    _threads[i].Start();
                }
            }
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false; // we might not want to execute task that should schedule as high or low priority inline
        }
    }
    public class Operations
    {
        private static int _runId = 0;
        public static void ExecuteSimultaneously(Action action1, Action action2)
        {
            Action slightlyEarlierStartingAction;
            Action slightlyLaterStartingAction;
            if (Interlocked.Increment(ref _runId) % 2 == 0)
            {
                slightlyEarlierStartingAction = action1;
                slightlyLaterStartingAction = action2;
            }
            else
            {
                slightlyEarlierStartingAction = action2;
                slightlyLaterStartingAction = action1;
            }
            int sync = 0;
            var cancellationToken = new CancellationToken();
            var taskA = Task.Factory.StartNew(() =>
            {
                Interlocked.Increment(ref sync);
                while (Interlocked.CompareExchange(ref sync, 3, 2) != 2) ;
                slightlyLaterStartingAction();
            }, cancellationToken, TaskCreationOptions.None, PriorityScheduler.Highest);
            var taskB = Task.Factory.StartNew(() =>
            {
                while (Interlocked.CompareExchange(ref sync, 2, 1) != 1) ;
                slightlyEarlierStartingAction();
            }, cancellationToken, TaskCreationOptions.None, PriorityScheduler.Highest);
            Task.WaitAll(taskA, taskB);
        }
    }
