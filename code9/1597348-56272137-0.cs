     [FunctionName(nameof(Store))]
        public static async Task<IActionResult> Store(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [Blob(
                "firstcontainer",
                FileAccess.Read,
                Connection = "blobConnection")] CloudBlobContainer blobContainer,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string filename = "nextlevel/body.json";
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{filename}");
            blob.Properties.ContentType = "application/json";
            await blob.UploadTextAsync(requestBody);
            return (ActionResult)new OkResult();
        }
