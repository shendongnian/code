    var threadid = Thread.CurrentThread.ManagedThreadId;
    Log.Debug($"Entry ThreadID: {threadid}");
    var getReportTask = ReportService.GetReportAsync(requestModel);
    getReportTask.ContinueWith(antecedent =>
    {
        var continuationThreadid = Thread.CurrentThread.ManagedThreadId;
        Log.Debug($"continuationThreadid: {continuationThreadid}");
        var result = antecedent.Result;
        if (result.PolicyModels != null)
        {
            AddPoliciesCountInNewRelic(result.PolicyModels.Count);
            AddTotalTransactionsCountInNewRelic(
                                result.PolicyModels.SelectMany(p => p.PolicyTransactionModels).Count());
        }
    }, TaskScheduler.FromCurrentSynchronizationContext());
    
    var reportObject = await getReportTask.ConfigureAwait(false);
