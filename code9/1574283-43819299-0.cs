    public class SampleElasticClient
    {
        private const string VERSION_CONFLICT_ERROR = "version_conflict_engine_exception";
        protected readonly string IndexName;
        protected readonly ElasticClient Client;
        public SampleElasticClient(Uri uri, string indexName)
        {
            Client = new ElasticClient(new ConnectionSettings(uri).DefaultIndex(indexName));
            IndexName = indexName;
        }
        public IGetResponse<T> Get<T>(Id id) where T : class
        {
            var request = new GetRequest<T>(IndexName, typeof(T), id);
            var response = Client.Get<T>(request);
            EnsureSuccessResponse(response);
            return response;
        }
        public void Update<T>(Id id, Func<T, T> update, int retriesCount = 10) where T : class
        {
            Retry(() =>
            {
                var getResponse = Get<T>(id);
                var item = update(getResponse.Source);
                return Client.Index(item, index => getResponse.Found
                    ? index.Version(getResponse.Version)
                    : index.OpType(OpType.Create));
            }, retriesCount);
        }
        protected void EnsureSuccessResponse(IResponse response)
        {
            if (!response.IsValid && response.ApiCall.HttpStatusCode != 404)
            {
                var errorMessage = response.ServerError != null
                    ? $"ElasticSearch error: {response.ServerError.Error}\r\n" +
                                   $"Http status: {response.ServerError.Status}"
                    : $"ElasticSearch error. {response.DebugInformation}";
                throw new Exception(errorMessage);
            }
        }
        protected void Retry(Func<IResponse> execute, int retriesCount)
        {
            var numberOfRetry = 0;
            do
            {
                var response = execute();
                if (response.ServerError?.Error.Type != VERSION_CONFLICT_ERROR || ++numberOfRetry == retriesCount)
                {
                    EnsureSuccessResponse(response);
                    return;
                }
            } while (true);
        }
    }
