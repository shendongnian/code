    public async Task<IEnumerable<TaskObject>> GetTaskObjects2()
    {
            var tasks = new List<Task<TaskObject>>();
            var shizzle = Task.Run(() => { Thread.Sleep(2000); return new TaskObject("1"); });
            var shizzle2 = Task.Run(() => { Thread.Sleep(1000); return new TaskObject("2"); });
            //Add your task to the collection
            tasks.Add(shizzle);
            tasks.Add(shizzle2);
            //wait for when all task are finished and it will return the data.
            return await Task.WhenAll(tasks);
        }
