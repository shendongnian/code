    public class MyDotNetActivity : IDotNetActivity
    {
        public IDictionary<string, string> Execute(IEnumerable<LinkedService> linkedServices, IEnumerable<Dataset> datasets, Activity activity, IActivityLogger logger)
        {
            return ExecuteAsync(linkedServices, datasets, activity, logger).Result;
        }
        async Task<IDictionary<string, string>> ExecuteAsync(IEnumerable<LinkedService> linkedServices, IEnumerable<Dataset> datasets, Activity activity, IActivityLogger logger)
        {
            List<int> personIds = await GetPersonIds("{clientAddress}", "{clientUsername}", "{clientPassword}");
            var tasks = new List<Task<List<CustomApiResult>>>();
            foreach (var personIdsBatch in personIds.Batch(100))
            {
                tasks.AddRange(GetCustomResultsByBatch("{address}", "{username}", "{password}", "{personIdsBatch}"));
            }
            var taskResults = await Task.WhenAll(tasks);
            List<CustomApiResult> customResults = taskResults.SelectMany(r=>r).ToList();
            //process the custom api results
            return new Dictionary<string, string>();
        }
        async Task<List<CustomApiResult>> GetCustomResultsByBatch(string address, string username, string password, IEnumerable<int> personIdsBatch)
        {
            //Get Custom Results By Batch
            return new List<CustomApiResult>();
        }
        async Task<List<int>> GetPersonIds(string clientAddress, string clientUsername, string clientPassword)
        {
            //load a list of people from a file in Azure Blob storage
            return new List<int>(); 
        }
    }
