    static void Main()
    {
        var config = new JobHostConfiguration()
        {
            DashboardConnectionString= ConfigurationManager.AppSettings["AzureWebJobsDashboard"],
            StorageConnectionString= ConfigurationManager.AppSettings["AzureWebJobsStorage"]
        };
        if (config.IsDevelopment)
        {
            config.UseDevelopmentSettings();
        }
        var host = new JobHost(config);
        // The following code ensures that the WebJob will be running continuously
        host.RunAndBlock();
    }
