    public class UploadController : ApiController
    {
        private const string Container = "mycontainer";
        [HttpPost]
        public async Task<IHttpActionResult> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
         
            var storageAccount = CloudStorageAccount.Parse("connection string");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer imagesContainer = blobClient.GetContainerReference(Container);
            var provider = new AzureStorageMultipartFormDataStreamProvider(imagesContainer);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error has occured. Details: {ex.Message}");
            }
            // Retrieve the filename of the file you have uploaded
            var filename = provider.FileData.FirstOrDefault()?.LocalFileName;
            if (string.IsNullOrEmpty(filename))
            {
                return BadRequest("An error has occured while uploading your file. Please try again.");
            }
            return Ok($"File: {filename} has successfully uploaded");
        }
    }
