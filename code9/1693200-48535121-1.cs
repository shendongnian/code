    public class TaskManager : ITaskManager
    {
        private readonly ConcurrentDictionary<string, TaskCompletionSource<Task>> _taskAwaiterMap = new ConcurrentDictionary<string, TaskCompletionSource<Task>>();
    
        public async Task GetTaskForKey(string key)
        {
            await await this._taskAwaiterMap.GetOrAdd(key, _ => new TaskCompletionSource<Task>()).Task;
        }
    
        public void QueueTask(string key, Task task)
        {
            this._taskAwaiterMap.GetOrAdd(key, _ => new TaskCompletionSource<Task>()).SetResult(task);
        }
    }
