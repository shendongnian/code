    private async void TaskRunProxy()
    {
        _TasksCounter += 1;
        MyTaskResults _Task = new MyTaskResults
        {
            TaskID = _TasksCounter,
            TextDirPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
            ImagesDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
            NativesDirPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
        };
            Console.WriteLine("Page File Size: " + Environment.SystemPageSize.ToString());
            Console.WriteLine("Memory (Working Set): " + Environment.WorkingSet.ToString());
            Stopwatch _SW = new Stopwatch();
            _SW.Start();
            CriticalJobRunning = true;
            _ListOfTasks.Add(await GetFileListsAsync(_Task));
            CriticalJobRunning = false;
            _SW.Stop();
            Console.WriteLine("Time: " + _SW.ElapsedMilliseconds + Environment.NewLine);
            Console.WriteLine("TextFiles: " +  _Task.TextDirPathResult.Count + 
                            "  ImageFiles: " + _Task.ImagesDirPathResult.Count + 
                            "  NativeFiles: " + _Task.NativesDirPathResult.Count);
            Console.WriteLine("Page File Size: " + Environment.SystemPageSize.ToString());
            Console.WriteLine("Memory (Working Set): " + Environment.WorkingSet.ToString());
    }
    private void wMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (this.CriticalJobRunning)
            e.Cancel = true;
        //Let the use know
    }
