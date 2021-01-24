    string appName = "fabric:/MyApplication";
    string appType = "MyApplicationType";
    string appVersion = "1.0.0";
    var fabricClient = new FabricClient();
        
    //  Create the application instance.
    try
    {
       ApplicationDescription appDesc = new ApplicationDescription(new Uri(appName), appType, appVersion);
       await fabricClient.ApplicationManager.CreateApplicationAsync(appDesc);
    }
    catch (AggregateException ae)
    {
    }
