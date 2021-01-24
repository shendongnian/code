    public async Task StartFileDownload()
    {
        var downloadTask = StartDownload();
        var monitoringTask = StartMonitoringProgress();
        await Task.WhenAll(downloadTask, monitoringTask);
    }
