    // Get the active project
    public static MSProject.Project ActiveProject = Globals.ThisAddIn.Application.ActiveProject;
        // Iterating over tasks in active project
        foreach (MSProject.Task oSubTask in ActiveProject.Tasks)
         {
            // Do something with the task
         }
        // If you want a particular task, set the index and choose the field
        string name = ActiveProject.Tasks[1].Name;
