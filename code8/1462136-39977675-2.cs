    public static class TaskTimeout
        {
            public static async Task TimeoutAfter(this Task task, int millisecondsTimeout)
            {
                if (task != await Task.WhenAny(task, Task.Delay(millisecondsTimeout)))
                { throw new TimeoutException(); }
            }
    
            public static async Task<T> TimeoutAfter<T>(this Task<T> task, int millisecondsTimeout)
            {
                if (task != await Task.WhenAny(task, Task.Delay(millisecondsTimeout)))
                { throw new TimeoutException(); }
                else { return task.Result; }
            }
        }
