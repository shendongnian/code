    BatchJob.Attach(mainBatchId, batch =>
    {
        var lockJobId = batch.Enqueue<IProcessJob>(job => job.ObtainLock(businessUnit));
    
        var preparationJobId = batch.ContinueWith<IPrepareProcessJob>(lockJobId,
            job => job.PrepareData(businessUnit, workingJobData, JobCancellationToken.Null));
    
        var statisticsJobId = batch.ContinueWith<IPrepareProcessJob>(preparationJobId,
            job => job.AddStatistics(businessUnit, workingJobData, JobCancellationToken.Null));
    
        batch.ContinueWith<IProcessJob>(statisticsJobId,
            job => job.ProcessFile(workingJobData, notifierInstructions, businessUnit,
                JobCancellationToken.Null));
    });
    
    // Catch-all unlock
    BatchJob.AwaitBatch(mainBatchId,
        batch => batch.Enqueue<IProcessJob>(job => job.ReleaseLock(businessUnit)),
        $"Unlock for {reportName}", BatchContinuationOptions.OnAnyFinishedState); 
