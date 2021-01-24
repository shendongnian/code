      var subscriptionId = "Your subscrption";
      var appId = "Registried Azure Application Id";
      var secretKey = "Secret Key";
      var tenantId = "tenant Id";
      var resourceGroup = "resource group name";
      var servicePlanName = "service plan name";
      var context = new AuthenticationContext("https://login.windows.net/" + tenantId);
      ClientCredential clientCredential = new ClientCredential(appId, secretKey);
      var tokenResponse = context.AcquireTokenAsync("https://management.azure.com/", clientCredential).Result;
      var accessToken = tokenResponse.AccessToken;
      TokenCredentials credential = new TokenCredentials(accessToken);
      var webSiteManagementClient = new Microsoft.Azure.Management.WebSites.WebSiteManagementClient(credential);
      webSiteManagementClient.SubscriptionId = subscriptionId;
      var servicePlan = webSiteManagementClient.AppServicePlans.ListByResourceGroupWithHttpMessagesAsync(resourceGroup).Result.Body.Where(x=>x.Name.Equals(servicePlanName)).FirstOrDefault();
       //scale up/down
        servicePlan.Sku.Family = "P"; 
        servicePlan.Sku.Name = "P1";
        servicePlan.Sku.Size = "P1";
        servicePlan.Sku.Tier = "Premium";
        servicePlan.Sku.Capacity = 2; // scale out: number of instances 
       var updateResult = webSiteManagementClient.AppServicePlans.CreateOrUpdateWithHttpMessagesAsync(resourceGroup, servicePlanName, servicePlan).Result;
