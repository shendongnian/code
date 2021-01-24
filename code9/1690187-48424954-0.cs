    public static void StartWithErrorLogging(Func<Task> task, IAresLogger logger)
    {
        Task.Run(async () =>
        {
            try
            {
                await task.Invoke();
            }
            catch (Exception e)
            {
                logger?.Log(LogMessageSeverity.Error, e.Message, e);
            }
        });
    }
