    public class DocumentRepository
    {
        private static readonly DocumentClient _client;
        static DocumentRepository()
        {
            var connectionPolicy = new ConnectionPolicy
            {
                RetryOptions = new RetryOptions()
                {
                    MaxRetryAttemptsOnThrottledRequests = 5,
                    MaxRetryWaitTimeInSeconds = 5
                }
            };
            _client = new DocumentClient(
                new Uri(ConfigurationManager.AppSettings["DocumentDbEndpointUrl"]),
                ConfigurationManager.AppSettings["DocumentDbAuthKey"],
                connectionPolicy);
        }
        public DocumentRepository()
        {
            DatabaseName = ConfigurationManager.AppSettings["DocumentDbDatabaseName"];
            PageSize = Int16.Parse(ConfigurationManager.AppSettings["DefaultPageSize"]);
            var _database = ReadOrCreateDatabase();
            var collection = InitialiseCollection(_database.SelfLink, EntityName);
            DocumentsLink = collection.DocumentsLink;
            SelfLink = collection.SelfLink;
        }
        public async Task UpdateAsync(TimelineEvent timelineEvent, string selfLink)
        {
            //TODO:
            await _client.UpsertDocumentAsync("{documentCollectionUri}", timelineEvent);
        }
    }
