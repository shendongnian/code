    public static void list_table()
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("xxxxxxxxxxxxxxxxxxxxxx_AzureStorageConnectionString"));
        CloudTableClient tableClient = new CloudTableClient(storageAccount.TableEndpoint, storageAccount.Credentials);
        var result = tableClient.ListTables();          
        if(result != null)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            } 
        }
    }
