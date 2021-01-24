run.csx
    #r "System.Drawing"
    #r "PresentationCore"
    #r "WindowsBase"
    #r "Microsoft.WindowsAzure.Storage"
    
    using Microsoft.WindowsAzure.Storage.Blob;
    using System.Drawing.Imaging;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    public static void Run(Stream imageStream, string imageName, string extension, CloudBlockBlob outputBlob, TraceWriter log)
    {
        log.Info($"Function triggered by blob\n Name:{imageName} \n Size: {imageStream.Length} Bytes");
    
    	var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.None);
    	BitmapFrame image = decoder.Frames[0];
    	
    	double ratio = Math.Min(200 / (double)image.PixelWidth, 200 / (double)image.PixelHeight);
    	var target = new TransformedBitmap(image, new ScaleTransform(ratio, ratio, 0, 0));
    	image = BitmapFrame.Create(target);
    	
    	var encoder = new JpegBitmapEncoder() { QualityLevel = 85 };
    	encoder.Frames.Add(image);
    
        using (var outputStream = new MemoryStream())
    	{
    	    encoder.Save(outputStream);
    		outputStream.Position = 0;
    		outputBlob.Properties.ContentType = "image/jpeg";
    		outputBlob.UploadFromStream(outputStream);
    	}
    }
function.json
    {
      "bindings": [
        {
          "name": "imageStream",
          "type": "blobTrigger",
          "direction": "in",
          "path": "input-container/{imageName}.{extension}",
          "connection": "AzureWebJobsDashboard"
        },
        {
          "type": "blob",
          "name": "outputBlob",
          "path": "output-container/{imageName}.jpg",
          "connection": "AzureWebJobsDashboard",
          "direction": "inout"
        }
      ],
      "disabled": false
    }
