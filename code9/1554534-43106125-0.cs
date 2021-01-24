    public async Task<bool> ExecuteAsync(string searchToken)
    {
        var reportTaskResult = await _webService.RetrieveReportAsync(searchToken, "PDF");
        var nextStepTasks = new List<Task<bool>>();
        // Run "print" task after report task.
        var printTask = _printCommandHandler.ExecuteAsync((byte[]) reportTaskResult);
        nextStepTasks.Add(printTask);
        // Run "save" task after report task.
        if (_configurationSettings.ConfigurationSetting.HasValue)
        {
            var saveTask = _saveCommandHandler.ExecuteAsync((byte[]) reportTaskResult);
            nextStepTasks.Add(saveTask);
        }
        var reportTaskResult = await Task.WhenAll(nextStepTasks);
        return reportTaskResult.Aggregate(false, (current, result) => current | result);
    }
