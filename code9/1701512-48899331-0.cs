    var clientId = "clientId ";
    var clientSecret = "clientSecret";
    var tenantId = "tenant Id";
    var resoureGroupName = "resource group name";
    var vmScalesetName = "vm scale set name";
    var subscriptionName = "subscriptionName";
    var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(clientId, clientSecret,
                tenantId, AzureEnvironment.AzureGlobalCloud);
    var azure = Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials)
                .WithDefaultSubscription();
    var vMachineScaleSet = azure.VirtualMachineScaleSets.GetByResourceGroup(resoureGroupName, vmScalesetName);
         
    var computeManagementClient =
                new ComputeManagementClient(credentials) {SubscriptionId = subscriptionName };
    var update=  computeManagementClient.VirtualMachineScaleSets.CreateOrUpdateWithHttpMessagesAsync(resoureGroupName, vmScalesetName,
                new VirtualMachineScaleSetInner
                { 
                   Location = vMachineScaleSet.RegionName,
                   Sku = new Sku
                   {
                       Capacity = 2, //set instance count
                       Name = vMachineScaleSet.Sku.Sku.Name,
                       Tier = vMachineScaleSet.Sku.Sku.Tier
                   }
                }).Result;
