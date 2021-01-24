    public async Task<IActionResult> Hello()
    {
        string connectionString = "something here";
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        var table = tableClient.GetTableReference("people");
        await table.CreateIfNotExistsAsync();
    }
