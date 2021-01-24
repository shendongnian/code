    private void ShowLoadingTextMenuItem_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
    {
        // This part is very important because on the following call  
        // to FromCurrentSynchronizationContext() you can get an exception
        if (SynchronizationContext.Current == null)
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
        }
        var context = TaskScheduler.FromCurrentSynchronizationContext();
        var task = new Task(() =>
        {
            // Disable excel application interactivity
            // you can avoid this and user will be able to use the UI
            // but there is the possibility to get HRESULT: 0x800AC472 Exception
            // when the long processing ends and you try to update the UI
            // which is probably coming because main UI thread is busy  
            Globals.ThisAddIn.Application.Interactive = false;
            // This is a simple class that is just showing WordArt text
            // in the middle of screen to indicate the loading process
            LoadingOverlayHelper.StartLoading();
        });
        Task continuation = task.ContinueWith(t =>
        {
            Globals.ThisAddIn.Application.StatusBar = "Doing some long processing task ...";
            
            // At this point you start the long processing task
            Thread.Sleep(4000);
            
            // And when its over remove the processing text
            LoadingOverlayHelper.StopLoading();
            Globals.ThisAddIn.Application.StatusBar = "Ready";
            Globals.ThisAddIn.Application.Interactive = true;
        }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, context);
        // Execute the task !
        task.Start();
    }
