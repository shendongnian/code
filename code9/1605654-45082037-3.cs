     public ActionResult loadMyBlob()
        {
         CloudBlobContainer blobContainer = _blobServices.GetCloudBlobContainer();
                    List<string> blobs = new List<string>();
                    foreach (var blobItem in blobContainer.ListBlobs())
                    {
                        blobs.Add(blobItem.Uri.ToString());
        
                    }
        
        return PartialView("loadMyBlob", blobs);
        
        }
