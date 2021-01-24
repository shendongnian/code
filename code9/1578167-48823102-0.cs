        var fabricClient = new FabricClient();
        var apps = fabricClient.QueryManager.GetApplicationListAsync().Result;
        foreach (var app in apps)
        {
            System.Diagnostics.Debug.WriteLine($"Discovered application:'{app.ApplicationName}");
            var services = fabricClient.QueryManager.GetServiceListAsync(app.ApplicationName).Result;
            foreach (var service in services)
            {
                System.Diagnostics.Debug.WriteLine($"Discovered Service:'{service.ServiceName}");
                var partitions = fabricClient.QueryManager.GetPartitionListAsync(service.ServiceName).Result;
                if (service.ServiceKind != System.Fabric.Query.ServiceKind.Stateful )
                {
                    continue;
                }
         }
