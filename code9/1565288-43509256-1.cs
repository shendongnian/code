    public static IEnumerable<GalleryPhoto> GetGalleryPhotos(string folderPath)
     {
    
            var container = CreateAzureContainer(containerName, false);
            container.FetchAttributes();
            var blobDirectory = container.GetDirectoryReference(folderPath);
            var photoGalleries = new List<GalleryPhoto>();
            var blobs = blobDirectory.ListBlobs(false, BlobListingDetails.Metadata).ToList();
    
           ...rest of code
      }
