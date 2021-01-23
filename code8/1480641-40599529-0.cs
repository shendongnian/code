    Do = new GalaSoft.MvvmLight.Command.RelayCommand(()=>
                {
                    var progress = new Progress<int>();
                    progress.ProgressChanged += (s, p) => Progress = p;
                    //Run and forget 
                    DoWork(progress);
                });
    public async Task DoWork(IProgress<int> progress = null)
            {
                await Task.Run(() =>
                {
                    for (int i = 1; i < 11; i++)
                    {
                        var count = 0;
                        for (int j = 0; j < 10000000; j++)
                        {
                            count += j;
                        }
                        progress.Report(i * 10);
                    }
                });
            }
