    var taskWaitASec = Task.Delay(TimeSpan.FromSeconds(1));
    var taskGetData = WebService.Instance.GetData();
    // note: you are not awaiting yet, so you program continues:
    while (!taskGetData.IsCompleted)
    {
        var myTasks = new Task[] {taskWaitASec, taskGetData}
        var completedTask = await Task.WhenAny(myTasks);
        if (completedTask == taskWaitASec)
        {
            UpdateProgress();
            taskWaitASec = Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
