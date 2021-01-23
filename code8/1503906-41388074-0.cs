    void EnumAllTasks()
    {
       using (TaskService ts = new TaskService())
          EnumFolderTasks(ts.RootFolder);
    }
    
    void EnumFolderTasks(TaskFolder fld)
    {
       foreach (Task task in fld.Tasks)
          ActOnTask(task);
       foreach (TaskFolder sfld in fld.SubFolders)
          EnumFolderTasks(sfld);
    }
    
    void ActOnTask(Task t)
    {
       // Do something interesting here
    }
