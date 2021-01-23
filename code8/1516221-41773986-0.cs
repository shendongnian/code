    public static string UploadBlob(string blobContainerName, string key, Stream sourceStrem, string contentType)
    {
    	//getting the storage account
    	string uri = null;
    	try
    	{
    		blobContainerName = blobContainerName.ToLowerInvariant();
    		string azureStorageAccountConnection =
    			ConfigurationManager.ConnectionStrings["AzureStorageAccount"].ConnectionString;
    		CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(azureStorageAccountConnection);
    		CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
    		
    		CloudBlobContainer container = cloudBlobClient.GetContainerReference(blobContainerName);
    		container.CreateIfNotExists();
    
    		CloudBlockBlob blob = container.GetBlockBlobReference(key);
    		blob.Properties.ContentType = contentType;
    		
    		blob.UploadFromStream(sourceStrem);
    		uri = blob.Uri.ToString();
    	}
    	catch (Exception exception)
    	{
    		if (_logger.IsErrorEnabled)
    			_logger.Error(exception.Message, exception);
    	}
    	return uri;
    }
