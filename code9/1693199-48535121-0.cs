    public class TaskManager : ITaskManager
    {
        private readonly ConcurrentDictionary<string, TaskCompletionSource<Task>> _taskAwaiterMap = new ConcurrentDictionary<string, TaskCompletionSource<Task>>();
    
        public Task<Task> GetTaskForKey(string key)
        {
            return this._taskAwaiterMap.GetOrAdd(key, _ => new TaskCompletionSource<Task>()).Task;
        }
    
        public void QueueTask(string key, Task task)
        {
            this._taskAwaiterMap.GetOrAdd(key, _ => new TaskCompletionSource<Task>()).SetResult(task);
        }
    }
