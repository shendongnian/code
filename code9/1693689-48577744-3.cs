    var blobname = ctnt.Headers.ContentDisposition.FileName.Trim('"');
    CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobname);
    //set the content-type for the current blob
    blockBlob.Properties.ContentType = ctnt.Headers.ContentType.MediaType;
    await blockBlob.UploadFromStreamAsync(await ctnt.Content.ReadAsStreamAsync(), null,requestOption,null);
