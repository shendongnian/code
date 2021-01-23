    public static void UploadImage_URL(string file, string ImageName)
	{
		string accountname = "<YOUR_ACCOUNT_NAME>";
		string accesskey = "<YOUR_ACCESS_KEY>";
		try
		{
			StorageCredentials creden = new StorageCredentials(accountname, accesskey);
			CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);
			CloudBlobClient client = acc.CreateCloudBlobClient();
			CloudBlobContainer cont = client.GetContainerReference("<YOUR_CONTAINER_NAME>");
			cont.CreateIfNotExists();
			cont.SetPermissions(new BlobContainerPermissions
			{
				PublicAccess = BlobContainerPublicAccessType.Blob
			});
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(file);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream inputStream = response.GetResponseStream();
			CloudBlockBlob cblob = cont.GetBlockBlobReference(ImageName);
			cblob.UploadFromStream(inputStream);
		}
		catch (Exception ex){ ... }
	}
