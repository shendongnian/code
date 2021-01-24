    var task1 = Task.Factory.StartNew(() =>
    {
        Test();
    }).ContinueWith((previousTask) =>
    {
        if (previousTask.Exception != null) {
            // do something with it
            throw previousTask.Exception.GetBaseException();
        }
        Test2();
    }); // note that task1 here is `ContinueWith` task, not first task
