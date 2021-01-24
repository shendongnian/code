    async Task Execute( IEnumerable<Func<Task>> taskFunctions, int maxParallel )
    {
        var taskList = new List<Task>(maxParallel);
        foreach ( var taskFunc in taskFunctions )
        {
            var task = taskFunc();
            taskList.Add( task );
            if ( taskList.Count == maxParallel )
            {
                var idx = await Task.WhenAny( taskList ).ConfigureAwait(false);
                taskList.RemoveAt( idx );
            }
        }
        await Task.WhenAll( taskList ).ConfigureAwait(false);
    }
        
