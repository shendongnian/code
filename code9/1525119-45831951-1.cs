    var currentEndpoint = "";
    try
    {
      IList<ServiceInstanceListener> listeners = new List<ServiceInstanceListener>();
      var endpoints = FabricRuntime.GetActivationContext().GetEndpoints();
      foreach (var endpoint in endpoints)
      {
        currentEndpoint = endpoint.Name;
        logger.LogInformation("Website trying to LISTEN : " + currentEndpoint);
        var webListner = new ServiceInstanceListener(serviceContext =>
           new WebListenerCommunicationListener(serviceContext, endpoint.Name, (url, listener) =>
           {
             url = endpoint.Protocol + "://+:" + endpoint.Port;
             logger.LogInformation("Website Listening : " + currentEndpoint);
             return new WebHostBuilder().UseWebListener()		.UseContentRoot(Directory.GetCurrentDirectory())
                  .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                  .UseStartup<Startup>()
                  .UseUrls(url)
                  .Build();
           }), endpoint.Name.ToString());
        listeners.Add(webListner);
      }
      return listeners;
    }
    catch (Exception ex)
    {
      logger.LogError("Exception occured while listening endpoint: " + currentEndpoint, ex);
      throw;
    }
    
