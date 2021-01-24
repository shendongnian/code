    BackgroundWorker bwTestAll = new BackgroundWorker() { WorkerReportsProgress = true };
     bwTestAll.DoWork += new DoWorkEventHandler(TestAll);
            bwTestAll.RunWorkerCompleted += TestAll_RunWorkerCompleted;
    //this is where I initialize my loading ring and other stuff and marshall background
    //worker to do the main work
     Dispatcher.Invoke(new Action(() =>
                    {
                        EnableLoading = true;
                        RunAllScriptsTest.IsEnabled = false;
                    }), DispatcherPriority.ContextIdle);
                    bwTestAll.RunWorkerAsync();
    //this is my main work
      void TestAll(object sender, DoWorkEventArgs e)
        {
            presenter.RunAllScripts(true);
        }
    //this is where I do my post-work stuff
     private void TestAll_RunWorkerCompleted(object sender,
                                       RunWorkerCompletedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                /
                EnableLoading = false;
                RunAllScriptsTest.IsEnabled = true;
                DbExecGrid = this.ExecutionResults;
                ShowOrHideExecGrid(this.EnableOrDisableGrid);
            }), DispatcherPriority.ContextIdle);
        } 
