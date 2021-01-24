    void PeriodicallyCheckSomething()
    {
        Task.Run(() => {
            var isTaskComplete = false;
            while (!isTaskComplete)
            {
                CancellationToken.WaitHandle.Wait(5000);
                if (CancellationToken.IsCancellationRequested)
                    return;
                isTaskComplete = CheckProgress();
            }
        });
    }
    bool CheckProgress()
    {
        var data = MakeWebRequest();
        return (data.Result == 999);
    }
