    var files = Directory.EnumerateFileSystemEntries(@"E:\Nouveau dossier (2)", "*.*", SearchOption.AllDirectories);
    var tasks = new List<Task>();
    foreach (var f in files)
    {
        var task = ToDoAsync(f);
        tasks.Add(task);
    } 
    await Task.WhenAll(tasks.ToArray());
