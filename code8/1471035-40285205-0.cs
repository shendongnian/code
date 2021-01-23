    ///=================================================================================================
    /// <summary>   Handler in your View class. </summary>
    ///
    /// <param name="sender">   Source of the event. </param>
    /// <param name="e">        Event information. </param>
    ///=================================================================================================
    public async void ViewEventHandler(object sender, EventArgs e)
    {
        // Set some UI stuff
        // Here we need to use ConfigureAwait(true) since we will interact with the UI after this method call
        await PresenterActionMethod().ConfigureAwait(true);
            
        // Set some UI stuff again
    }
    ///=================================================================================================
    /// <summary>
    ///     This method is inside your Presenter class and is expected to return once the long
    ///     running method of your Model is finished.
    /// </summary>
    ///
    /// <returns>   A Task. </returns>
    ///=================================================================================================
    public async Task PresenterActionMethod()
    {
        // Do stuff
        await ModelLongRunningTaskMethod().ConfigureAwait(false);
        // Do other stuff
    }
    ///=================================================================================================
    /// <summary>
    ///     This method is inside your Model class and is expected to be a long-running method.
    /// </summary>
    ///
    /// <returns>   A Task. </returns>
    ///=================================================================================================
    public async Task ModelLongRunningTaskMethod()
    {
        // ... do your stuff here
        // You should use ConfigureAwait(false) here since you don't need the captured context
        // this improves performance and reduces the risk of deadlocks
        await Task.Delay(6000).ConfigureAwait(false);
    }
