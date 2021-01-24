    private void startProgressBarBA()
    {
        int tempBA = 0;
        proBing.Maximum = Int32.Parse(cboGeoThreshold.Text);
    
        CancellationTokenSource bingBarToken = new CancellationTokenSource();
        Task bingTask = Task.Factory.StartNew(() =>
        {
            while (!bingBarToken.Token.IsCancellationRequested)
            {
                if (tempBA != Base.proBaValue)//Reduce the number of same value assigned.
                {
                    try
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            if (proBing.Value == proBing.Maximum)
                            {
                                proBing.Value = 0;
                                Base.proBaValue = 0;
                            }
                            proBing.Value = Base.proBaValue;
                            tempBA = Base.proBaValue;
                            baRecord.Content = proBing.Value + "/" + proBing.Maximum;
                        }
                        ));
                    }
                    catch(OutOfMemoryException e)
                    {
                        throw e;
                    }
                }
                if (Base.checkTaskBA == false)
                {
                    bingBarToken.Cancel();
                }
    
                Thread.Sleep(100);
            }
        },bingBarToken.Token, TaskCreationOptions.LongRunning,TaskScheduler.Default);
    }
