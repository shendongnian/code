    public class TaskBatchRunner
    {
        private Task[] _tasks;
        public event EventHandler<Task> TaskCompleted;
        public TaskBatchRunner(Task[] tasks)
        {
            _tasks = tasks.Select(t =>
                new Task(() =>
                {
                    t.ContinueWith(OnTaskCompleted);
                    t.Start();
                })).ToArray();
        }
        public void Run()
        {
            foreach (var t in _tasks) t.Start();
            Task.WaitAll(_tasks);
        }
        private void OnTaskCompleted(Task completedTask)
        {
            TaskCompleted?.Invoke(this, completedTask);
        }
    }
