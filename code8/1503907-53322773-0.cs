    using TaskScheduler;
    
    private static void ProcessTaskFoler (ITaskFolder taskFolder)
    {
        int idx;
        string name, path;
        _TASK_STATE state;
    
        IRegisteredTaskCollection taskCol = taskFolder.GetTasks(1);  // 1 = TASK_ENUM_HIDDEN
        for (idx = 1; idx <= taskCol.Count; idx++)  // browse al tasks in folder
        {
            IRegisteredTask runTask = taskCol[idx];
    
            name = runTask.Name;
            path = runTask.Path;
            state = runTask.State;
            // retrieve other properties...
    
            Console.WriteLine(path);
        }
                
        ITaskFolderCollection taskFolderCol = taskFolder.GetFolders(0);  // 0 = reserved for future use
        for (idx = 1; idx <= taskFolderCol.Count; idx++)  // recursively browse subfolders
            ProcessTaskFoler(taskFolderCol[idx]);
    }
    
    private static void ParseScheduleTasks()
    {
        ITaskService taskService = new TaskScheduler.TaskScheduler();
        taskService.Connect();
                
        ProcessTaskFoler(taskService.GetFolder("\\"));
    }
