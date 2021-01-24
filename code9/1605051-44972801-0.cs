    async Task CallMethodAsync()
    {
        var progress = new Progress<double>();
        progress.ProgressChanged += OnProgressReported;
        await ExecuteMethodAsync(progress);
    }
    private void OnProgressReported(object sender, ...)
    {
        // because this thread has the context of the main thread no InvokeRequired!
        this.progressBar1.Increment(...);
    }
    private async void button1_Click(object sender, EventArgs e)
    {
        await CallMethodAsync();
    }
