    int SomeTask()
    {
        // Prevent executing the task by two threads at the same time.
        lock ("IsReady")
        {
            if (IsReady == false)
                throw new ApplicationException("Task is already running");
            Application.Current.Dispatcher.Invoke(() => { IsReady = false; });
        }
        //SCENARIO: Consider that it takes longer than usual to start the worker thread.
        Thread.Sleep(1000);
        // The actual work that this task consists of.
        TaskProgress = 0;
        for (int i = 1; i <= 100; i++)
        {
            Thread.Sleep(50);
            TaskProgress = i;
        }
        // Mark task as completed to allow rerunning it.
        Application.Current.Dispatcher.Invoke(() => { IsReady = true; });
        return 123;
    }
