       var credentials = SdkContext.AzureCredentialsFactory.FromFile(@"authentication file path");
       var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();
       var webFunctionAppName = "azure function name";
       var webFunctionApp = azure.AppServices.FunctionApps.List().Where(x => x.Name.Equals(webFunctionAppName))?.First();
       var ftpUsername = azure.AppServices.FunctionApps.GetById(webFunctionApp.Id).GetPublishingProfile().FtpUsername;
       var username = ftpUsername.Split('\\').ToList()[1];
       var password = azure.AppServices.FunctionApps.GetById(webFunctionApp.Id).GetPublishingProfile().FtpPassword;
       var base64Auth = Convert.ToBase64String(Encoding.Default.GetBytes($"{username}:{password}"));
       var file = File.ReadAllBytes(@"zip file path");
       MemoryStream stream = new MemoryStream(file);
    
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64Auth);
            var baseUrl = new Uri($"https://{webFunctionAppName}.scm.azurewebsites.net/");
            var requestURl = baseUrl+ "api/zip/site/wwwroot";
            var httpContent = new StreamContent(stream);
            var response = client.PutAsync(requestURl, httpContent).Result;
         }
