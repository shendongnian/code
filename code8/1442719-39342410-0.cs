    /// <summary>
    /// This is the main entry point for your service instance.
    /// </summary>
    /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
    protected override async Task RunAsync(CancellationToken cancellationToken)
    {
        ConfigurationPackage configPackage = this.Context.CodePackageActivationContext.GetConfigurationPackageObject("Config");
        KeyedCollection<string, ConfigurationProperty> parameters = configPackage.Settings.Sections["MyConfigSection"].Parameters;
        JobHostConfiguration config = new JobHostConfiguration();
        config.DashboardConnectionString = parameters["AzureWebJobsDashboard"].Value;
        config.StorageConnectionString = parameters["AzureWebJobsStorage"].Value;
        config.Queues.BatchSize = 10;
        config.Queues.MaxDequeueCount = 8;
        config.Queues.MaxPollingInterval = TimeSpan.FromSeconds(30);
        var host = new JobHost(config);
        host.CallAsync(typeof(TestStatelessService).GetMethod("ProcessMethod"),cancellationToken);
        host.RunAndBlock();
    }
    [NoAutomaticTrigger]
    public static async Task ProcessMethod(CancellationToken cancellationToken)
    {
        long iterations = 0;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            //log
            Trace.TraceInformation(">>[{0}]ProcessMethod Working-{1}",DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),++iterations);
            //sleep for 5s
            await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        }
    }
    [Timeout("00:03:00")]
    public static void ProcessNotificationsInQueue([QueueTrigger("newnotificationqueue")] CloudQueueMessage notification)
    {
        Trace.TraceInformation(">ProcessNotificationsInQueue invoked with notification:{0}", notification.AsString);
    }
