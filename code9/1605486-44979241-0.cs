    private void AddFile(Stream image)
    {
        InitializeKey();
        var uploadRequest = new TransferUtilityUploadRequest();
        uploadRequest.CannedACL = S3CannedACL.PublicRead;
        uploadRequest.InputStream = image;
        uploadRequest.BucketName = AppConfiguration.AmazonS3FileBucketName;
        uploadRequest.Key = _key;
        using (TransferUtility fileTransferUtility = new TransferUtility(_client))
        {
            fileTransferUtility.Upload(uploadRequest);
        }
    }
