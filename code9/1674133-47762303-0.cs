    // On you've got the ServiceBusManagementClient
    ServiceBusManagementClient sbClient = ...
    
    sbClient.Topics.CreateOrUpdateAsync("resource group name", "namespace name", "topic name", 
        new Microsoft.Azure.Management.ServiceBus.Models.SBTopic());
