    [Route("api/[controller]")]
    [Authorize]
    public class AzureStorageController : Controller
    {
        private AzureBlobStorageClient _storageClient;
        public ValuesController(AzureBlobStorageClient storageClient)
        {
            _storageClient = storageClient;
        }
        [HttpGet]
        public async Task<string> Get()
        {   
            //_storageClient.EnsureContainer("<blob-container-name>");
            return await Task.FromResult("hello world");
        }
    }
