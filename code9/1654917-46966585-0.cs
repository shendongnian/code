            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            ServiceProperties serviceProperties = blobClient.GetServicePropertiesAsync().Result;
            serviceProperties.Cors = new CorsProperties();
            serviceProperties.Cors.CorsRules.Clear();
            serviceProperties.Cors.CorsRules.Add(new CorsRule()
            {
                AllowedHeaders = new List<string>() { "*" },
                ExposedHeaders = new List<string>() { "*" },
                AllowedOrigins = new List<string>() { "*" },
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
                MaxAgeInSeconds = 1800
            });
           var re =  blobClient.SetServicePropertiesAsync(serviceProperties);
