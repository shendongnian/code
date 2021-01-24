    public static class WorkSpaceExtension
    {
        // Extend PendRename(String, String)
        public static int PendRename(this Workspace workspace,
            string[] oldPaths,
            string[] newPaths)
        {
            // Make sure that the oldPath and new Paths match
            if (oldPaths.Count() != newPaths.Count())
                throw new ArgumentException("Every oldPath must have corresponding newPath");
     
            // This list will contain all our tasks
            List pendRenameTasks = new List();
     
            // Loop throuh all newPath and oldPath pairs
            for (int i = 0; i < oldPaths.Count(); i++)
            {
                // Add each new task in out task container
                pendRenameTasks.Add(Task.Factory.StartNew((Object obj) =>
                {
                    // We are going to pass the current old path and the
                    // current new path into the path as an anonymous type
                    var path = (dynamic)obj;
                    return workspace.PendRename(path.oldPath, path.newPath);
                }, new { oldPath = oldPaths[i], newPath = newPaths[i] }));
            }
     
            // Wait for all tasks to complete
            Task.WaitAll(pendRenameTasks.ToArray());
     
            // Sum up the result of all the original PendRename method
            int taskCount=0;
            foreach (Task pendRenameTask in pendRenameTasks)
            {
                taskCount += pendRenameTask.Result;
            }
     
            // Return the number of file names changed
            return taskCount;
        }
    }
