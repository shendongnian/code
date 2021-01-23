    TaskCompletionSource<DialogResult> taskSource;
    Task<DialogResult> ShowAsync()
    {
        return taskSource.Task;
    }
    public void OkButton_OnClick(EventArgs e, object sender)
    {
        taskSource.SetResult(DialogResult.OK);
    }
    public void CancelButton_OnClick(EventArgs e, object sender)
    {
        taskSource.SetResult(DialogResult.Cancel);
    }
