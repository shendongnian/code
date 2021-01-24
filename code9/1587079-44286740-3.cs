    int ExecutionCounter = 0;
    object key = new object();
    Func<Task> myAction = async () =>
    {
        await Task.Delay(TimeSpan.FromMilliseconds(5));
        lock (key)
        {
            Console.WriteLine(++ExecutionCounter);
        }
    };
    var actions = new[] { myAction, myAction, myAction };
    Task.WaitAll(actions.Select(a => Execute(a)).ToArray());  //This blocks, right?
