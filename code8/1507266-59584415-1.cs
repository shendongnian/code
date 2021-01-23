    // Get a single timer job
    using (TaskService taskService = new TaskService())
    {
        Task[] allTimerJobs = GetAllTasks(taskService, prefix);
        List<Task> allTimerJobsList = allTimerJobs.Cast<Task>().ToList();
        string jobName = String.Format("{0}[{1}].{2}", prefix, (int)timerJobItem["ID"],jobReference);
        // Get Task by name
        int indexOfJob = allTimerJobsList.FindIndex(t => t.Name == jobName);
        Task matchingJob = allTimerJobsList[indexOfJob];
        // No Error but nothing happens to task
        matchingJob.Definition.Triggers.Clear();
        // No Error but nothing happens to task
        matchingJob.Definition.Settings.Enabled = false;
    }
