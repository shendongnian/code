    public static async Task<StorageAccount> CreateStorageAccountAsync(
      TokenCredentials credential,       
      string groupName,
      string subscriptionId,
      string location,
      string storageName)
    {
      Console.WriteLine("Creating the storage account...");
      var storageManagementClient = new StorageManagementClient(credential)
        { SubscriptionId = subscriptionId };
      return await storageManagementClient.StorageAccounts.CreateAsync(
        groupName,
        storageName,
        new StorageAccountCreateParameters()
        {
          Sku = new Microsoft.Azure.Management.Storage.Models.Sku() 
            { Name = SkuName.StandardLRS},
          Kind = Kind.Storage,
          Location = location
        }
      );
    }
