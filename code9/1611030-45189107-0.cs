    backGroundWorker.DoWork += (obj, e) =>
    {
        try
        {
            if (info == null)
            {
                Thread.Sleep(100);
                App.Current.Dispatcher.Invoke(DispatcherPriority.SystemIdle, new Action( delegate ()
                {
                    arg.result = AddqueryintoTable((CancellationToken)e.Argument);
                }));
                
                if (backGroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        catch (ThreadAbortException)
        {
            Dispatcher.Invoke(() =>
            {
                alertBox.IsBusy = false;
            }, System.Windows.Threading.DispatcherPriority.Background);
            e.Cancel = true;
        }  
    };
