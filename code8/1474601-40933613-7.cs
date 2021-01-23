    using Microsoft.Azure.WebJobs.Host;
        
    public static void TryLog(TraceWriter azureFunctionsLogger)
    {
        azureFunctionsLogger.Info("************** IT WORKED **************");
    }
