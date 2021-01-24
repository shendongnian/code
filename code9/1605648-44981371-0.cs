    class ImagesController : Controller {
        
        public ActionResult Index() {
            
            List<ImageVM> images;
            if( useAzure ) {
                
                List<CloudStorageBlob> blobs = GetBlobs( ... );
                images = blobs
                    // convert an Azure blob record into an ImageVM:
                    .Select( b => new ImageVM()
                    {
                        Url = b.BlobUrl
                    } )
                    .ToList();
            }
            else { // use local SQL
                
                List<MyImageEntity> dbImages = GetImagesFromDB( ... );
                images = dbImages
                    // convert a database MyImageEntity into an ImageVM:
                    .Select( i => new ImageVM()
                    {
                        Url = i.ImageAddress
                    } )
                    .ToList();
            }
            
            return this.View( images );
        }
    }
