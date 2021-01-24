     protected void Button5_Click(object sender, EventArgs e)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("connection string");
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                //check the b.Container value is right and exists
                CloudBlobContainer container = blobClient.GetContainerReference("foobar");
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("TestFile.pdf");
                HttpContext httpContext = HttpContext.Current;
                HttpServerUtility server = httpContext.Server;
                string FilePath = server.MapPath("~/test/TestFile.pdf");
                //by using this code will create the container if not exists
                container.CreateIfNotExists();
                blockBlob.UploadFromFile(FilePath);
             }
