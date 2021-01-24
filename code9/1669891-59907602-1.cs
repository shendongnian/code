    /// <summary>
    /// This method should be called in every View Code Behind when you
    /// need to subscribe to InitializeTask changes.
    /// </summary>
    public void OnViewModelSet()
    {
        if (this.InitializeTask is null)
        {
            return;
        }
        this.InitializeTask.PropertyChanged += this.InitializeTask_PropertyChanged;
    }
