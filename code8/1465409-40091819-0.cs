    // This Gets all the ID(s)-IEnumerable <int>
    var clientIds = new Clients().GetAllClientIds(); 
    // This gets all the tasks to be executed
    var tasks = clientIds.Select(id => ProcessId(id)).
    // this will create a task that will complete when all of the `Task` 
    // objects in an enumerable collection have completed. 
    await Task.WhenAll(tasks);
