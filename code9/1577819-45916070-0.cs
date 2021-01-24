run.csx
    #r "Microsoft.WindowsAzure.Storage"
    
    using Microsoft.WindowsAzure.Storage.Blob;
    using ImageResizer;
    using ImageResizer.ExtensionMethods;
    
    public static void Run(Stream imageStream, string blobName, CloudBlockBlob outputBlob, TraceWriter log)
    {
        log.Info($"Function triggered by blob\n Name:{blobName} \n Size: {imageStream.Length} Bytes");
    
     	var instructions = new Instructions
        {
            Width = 400,
    		Height = 350,
            Mode = FitMode.Max,
    		OutputFormat = OutputFormat.Jpeg,
    		JpegQuality = 85
        };
    
    	using (var outputStream = new MemoryStream())
    	{
        	ImageBuilder.Current.Build(new ImageJob(imageStream, outputStream, instructions));
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
          "path": "watched-container/{blobName}.jpg",
          "connection": "AzureWebJobsDashboard"
        },
        {
          "type": "blob",
          "name": "outputBlob",
          "path": "output-container/{blobName}.jpg",
          "connection": "AzureWebJobsDashboard",
          "direction": "inout"
        }
      ],
      "disabled": false
    }
project.json
    {
    "frameworks": {
      "net46":{
        "dependencies": {
          "ImageResizer": "4.0.5"
        }
      }
     }
    }
