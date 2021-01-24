    private bool IsExecuting { get; set; }
    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (!IsExecuting) 
        {
            IsExecuting = true;
            // rest of your code
            IsExecuting = false;
        }
    }
