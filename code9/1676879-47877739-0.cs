    static class Extensions
    {
        /// <summary>
        /// Start a new task that will run continuously for a given amount of time.
        /// </summary>
        /// <param name="taskFactory">Provides access to factory methods for creating System.Threading.Tasks.Task and System.Threading.Tasks.Task`1 instances.</param>
        /// <param name="action">The action delegate to execute asynchronously.</param>
        /// <param name="cancellationToken">The System.Threading.Tasks.TaskFactory.CancellationToken that will be assigned to the new task.</param>
        /// <param name="timeSpan">The interval between invocations of the callback.</param>
        /// <returns>The started System.Threading.Tasks.Task.</returns>
        public static Task StartNewTaskContinuously(this TaskFactory taskFactory, Action action, CancellationToken cancellationToken, TimeSpan timeSpan
            , string taskName = "")
        {
            return taskFactory.StartNew(async () =>
            {
                if (!string.IsNullOrEmpty(taskName))
                {
                    Debug.WriteLine("Started task " + taskName);
                }
                while (!cancellationToken.IsCancellationRequested)
                {
                    action();
                    try
                    {
                        await Task.Delay(timeSpan, cancellationToken);
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(taskName))
                {
                    Debug.WriteLine("Finished task " + taskName);
                }
            });
        }
    }
