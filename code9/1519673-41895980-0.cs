    var tc = new TaskController();
    var backTask1 = tc.CreateTask(1);
    var backTask2 = tc.CreateTask(2);   
    // task 2 gets cancelled         
    await tc.Cancel(2);
    try
    {
        var res2 = await backTask2;
    }
    catch (OperationCanceledException) { }
    // task 1 waits
    await backTask1;
