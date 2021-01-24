    public RelayCommand StartTaskCommand
    {
        get
        {
            if (_startTask == null)
            {
                _startTask = new RelayCommand(
                    obj =>
                    {
                        if (IsReady)
                        {
                            //1. Disable the button on the UI thread
                            IsReady = false;
                            //2. Execute SomeTask on a background thread
                            Task.Factory.StartNew(SomeTask)
                            .ContinueWith(t =>
                            {
                                //3. Enable the button back on the UI thread
                                if (!t.IsFaulted)
                                    Result = t.Result.ToString();
                                IsReady = true;
                            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
                        }
                    },
                    obj => IsReady);
            }
            return _startTask;
        }
    }
    int SomeTask()
    {
        Thread.Sleep(1000);
        TaskProgress = 0;
        for (int i = 1; i <= 100; i++)
        {
            Thread.Sleep(50);
            TaskProgress = i;
        }
        return 123;
    }
