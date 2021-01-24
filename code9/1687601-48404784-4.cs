    private async void TaskRunProxy()
    {
        _TasksCounter += 1;
        MyTaskResults _Task = new MyTaskResults
        {
            TaskID = _TasksCounter,
            TextDirPath = @"c:\TextDirPath",
            ImagesDirPath = @"c:\ImagesDirPath",
            NativesDirPath = @"c:\NativesDirPath"
        };
        Stopwatch _SW = new Stopwatch();
        _SW.Start();
        _ListOfTasks.Add(await GetFileListsAsync(_Task));
        _SW.Stop();
        Console.WriteLine("Time: {0}" + Environment.NewLine, _SW.ElapsedMilliseconds);
        Console.WriteLine("TextFiles: {0}  ImageFiles: {1}  NAtiveFiles: {2}", 
                           _Task.TextDirPathResult, 
                           _Task.ImagesDirPathResult, 
                           _Task.NativesDirPathResult);
    }
