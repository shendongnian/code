    // Here, we are on a background thread
    action = () =>
    {
        // This action is NOT executing yet!  We are just defining it.
        UpdateProgress(10, "Sampling calculations");
        // This is going to execute on the thread that executes this action!
        viewModel1 = Application.GetEchantillonnage();//Long process
    };
    // here, we are still on the background thread, but we are telling the
    // dispatcher to marshall the action onto the UI thread to execute it!
    dispatcher.BeginInvoke(action, dispatcherPriority);
