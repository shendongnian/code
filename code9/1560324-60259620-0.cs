    public interface IAzureServiceWrapper
    {
        CloudBlockBlob GetBlockBlobReference(CloudBlobContainer storageContainer, string fileName);
    }
    public class AzureServiceWrapper : IAzureServiceWrapper
    {
        public CloudBlockBlob GetBlockBlobReference(CloudBlobContainer storageContainer, string fileName)
        {
             storageContainer.GetBlockBlobReference(fileName).DeleteIfExists();
        }
    }
