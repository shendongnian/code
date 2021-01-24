    public Byte[] LoadAssetAsByteArray(string uri)
    {
        var nsUrl = new NSUrl(uri);
        var asset = new ALAssetsLibrary();
        Byte[] imageByteArray = new Byte[0];
        UIImage image;
    
        asset.AssetForUrl(nsUrl,(ALAsset obj) => {
            
          var assetRep = obj.DefaultRepresentation;
          var cGImage = assetRep.GetFullScreenImage();
          image = new UIImage(cGImage);
          // get as Byte[]
          imageByteArray = new Byte[image.AsPNG().Length];
          //imageView.Image = image;
        }, 
        (NSError err) => { 
            Console.WriteLine(err);
        });
    
        return imageByteArray;
    }
