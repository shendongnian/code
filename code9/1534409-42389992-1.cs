    5070    // Collects incomplete tasks in "waitedOnTaskList"
    5071    for (int i = tasks.Length - 1; i >= 0; i--)
    5072    {
    5073        Task task = tasks[i];
    5074
    5075        if (task == null)
    5076        {
    5077            throw new ArgumentException(Environment.GetResourceString("Task_WaitMulti_NullTask"), "tasks");
    5078        }
