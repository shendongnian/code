    private async Task ResumeAfterordersFormDialog(IDialogContext context, IAwaitable<object> result)
    {
        var searchQuery = await result as OrderSearchQuery;
        var itemnumber = searchQuery.ItemNumber;
        var draft = searchQuery.Draft;
    
        // Save the information;
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        CloudTableClient tableclient = storageAccount.CreateCloudTableClient();
        CloudTable table = tableclient.GetTableReference("SearchQuery");
        table.CreateIfNotExists();
    
        MyEntity entity = new MyEntity(itemnumber.ToString(), draft.ToString())
        {
            PartitionKey = itemnumber.ToString(),
            RowKey = DateTime.UtcNow.ToString("yyyyMMddhhmmss")
        };
        TableOperation insertOperation = TableOperation.Insert(entity);
        table.Execute(insertOperation);
    
        context.Wait(ResumeAfterordersFormDialog);
    }
    
    public class MyEntity : TableEntity
    {
        public MyEntity(string item, string draft)
        {
            this.Item = item;
            this.Draft = draft;
        }
    
        public string Item { get; set; }
        public string Draft { get; set; }
    }
