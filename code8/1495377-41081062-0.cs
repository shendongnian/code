	var files = Directory.EnumerateFileSystemEntries(@"E:\Nouveau dossier (2)", "*.*", SearchOption.AllDirectories);
	List<Task> tasks = new List<Task>();
	foreach (var f in files)
	{
		var local = f;
		var tast = Task.Run(() => ToDo(local));
		
		tasks.Add(task);
	}
	
	Task.WhenAll(tasks.ToArray());
