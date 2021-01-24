    public static class TaskExtension
    {
        /// <summary>
        /// Firebase Task might not play well with Unity's Coroutine workflow. You can now yield on the task with this.
        /// </summary>
        public static IEnumerator YieldWait(this Task task)
        {
            while (task.IsCompleted == false)
            {
                yield return null;
            }
            if(task.IsFaulted)
            {
                throw task.Exception;
            }
        }
    }
