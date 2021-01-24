     public class WebChatController : Controller
    {
        public ActionResult Index()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
    
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            
            CloudTable table = tableClient.GetTableReference("BotStore");
            string userId = Guid.NewGuid().ToString();
            TableQuery<BotDataRow> query = new TableQuery<BotDataRow>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId));
    
            var dataRow = table.ExecuteQuery(query).FirstOrDefault();
            if(dataRow != null)
            {
                dataRow.Data = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    UserName = "This user's name",
                    Email = "whatever@email.com",
                    GraphAccessToken = "token",
                    TokenExpiryTime = DateTime.Now.AddHours(1)
                });
                dataRow.Timestamp = DateTimeOffset.UtcNow;
                table.Execute(TableOperation.Replace(dataRow));
            }
            else
            {
                var row = new BotDataRow(userId, "userData");
                row.Data = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    UserName = "This user's name",
                    Email = "whatever@email.com",
                    GraphAccessToken = "token",
                    TokenExpiryTime = DateTime.Now.AddHours(1)
                });
                row.Timestamp = DateTimeOffset.UtcNow;
                table.Execute(TableOperation.Insert(row));
            }
    
            var vm = new WebChatModel();
            vm.UserId = userId;
            return View(vm);
        }
    
        public class BotDataRow : TableEntity
        {
            public BotDataRow(string partitionKey, string rowKey)
            {
                this.PartitionKey = partitionKey;
                this.RowKey = rowKey;
            }
    
            public BotDataRow() { }
            
            public bool IsCompressed { get; set; }
            public string Data { get; set; }
        }
    }
