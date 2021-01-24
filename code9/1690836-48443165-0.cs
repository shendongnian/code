    using System.IO;
    for (int i = 1; i < eventToHandle.Parameters.Count; i++)
    {
        if (eventToHandle.Parameters.ContainsKey($"DirectoryOne{i}") &&
            eventToHandle.CustomParameters[$"DirectoryOne{i}"] != null && 
            Directory.Exists(eventToHandle.CustomParameters[$"DirectoryOne{i}"].ToString()))
        {
            DirectoryInfo rootDir = new DirectoryInfo(eventToHandle.Parameters[$"DirectoryOne{i}"].ToString());
            FileInfo[] files = rootDir.GetFiles();
            DirectoryInfo[] subDirs = rootDir.GetDirectories();
        }
