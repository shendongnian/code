    task.ContinueWith(originalTask =>
    {
        var taskType = originalTask.GetType();
        object returnValue = taskType.GetProperty("Result")?.GetValue(originalTask, null);
        LogExit(args, returnValue);
    });
