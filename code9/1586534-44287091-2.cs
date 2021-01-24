    class AzureStreamRepository : IStreamRepository
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly string _containerName;
        public AzureStreamRepository( string connectionString, string containerName )
        {
            _storageAccount = CloudStorageAccount.Parse( connectionString );
            _containerName = containerName;
        }
        public async Task DeleteAsync( string id )
        {
            var blockBlob = GetBlockBlob( id );
            await blockBlob.DeleteAsync();
        }
        public async Task<Stream> GetAsync( string id )
        {
            var blockBlob = GetBlockBlob( id );
            Stream result = new MemoryStream();
            try
            {
                await blockBlob.DownloadToStreamAsync( result );
            }
            catch ( Exception )
            {
                result.Dispose();
                throw;
            }
            result.Seek( 0, SeekOrigin.Begin );
            return result;
        }
        public async Task PutAsync( string id, Stream stream )
        {
            var blockBlob = GetBlockBlob( id );
            await blockBlob.UploadFromStreamAsync( stream );
        }
        private Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob GetBlockBlob( string id )
        {
            var client = _storageAccount.CreateCloudBlobClient();
            var container = client.GetContainerReference( _containerName );
            return container.GetBlockBlobReference( id );
        }
    }
