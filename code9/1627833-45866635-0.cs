    public async Task<string> UploadFile(string containerName, IFormFile file)
    {
        //string blobPath = "";
        var container = GetContainer(containerName);
        var fileName = file.FileName;
        CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
        await blob.UploadFromStreamAsync(file.OpenReadStream())
        return blob.Uri.AbsoluteUri;
    }
