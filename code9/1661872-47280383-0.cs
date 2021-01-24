    protected void Page_Load(object sender, EventArgs e)
    {
        var blobStorageName = Request.QueryString["blobStorageName"];
        var companyID = Request.QueryString["companyID"];
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Microsoft.Azure.CloudConfigurationManager.GetSetting("StorageConnectionString"));
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(System.Text.RegularExpressions.Regex.Replace(companyID.ToLower(), @"\s+", ""));
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobStorageName);
        System.IO.MemoryStream memStream = new System.IO.MemoryStream();
        blockBlob.DownloadToStream(memStream);
        HttpResponse response = HttpContext.Current.Response;
        response.ContentType = blockBlob.Properties.ContentType;
        response.AddHeader("Content-Disposition", "Attachment; filename=" + blobStorageName.ToString());
        response.AddHeader("Content-Length", blockBlob.Properties.Length.ToString());
        response.BinaryWrite(memStream.ToArray());
    }
 
