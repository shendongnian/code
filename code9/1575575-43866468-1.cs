    var inputFile = new MediaFile {Filename = @"C:\Path\To_Video.flv"};
    var outputName = "C:\Path\To_Save_ExtractedVideo";
    var outputExtension = ".flv";
    
    double t = inputFile.Length/4; //length of parts -- need to use method to get file playtime length
    for(int i=0;i<4;i++){
    
        var engine = new Engine()
        engine.GetMetadata(inputFile);
        var options = new ConversionOptions();
        // This example will create a 25 second video, starting from the 
        // 30th second of the original video.
        //// First parameter requests the starting frame to cut the media from.
        //// Second parameter requests how long to cut the video.
        options.CutMedia(TimeSpan.FromSeconds(30 + (i*int.Parse(t))), TimeSpan.FromSeconds((i+1)*int.Parse(t)));
    
        engine.Convert(inputFile, $"{outputName}_{i.ToString()}{outputExtension}, options);
        engine.Destroy(); // Need to destroy object or close inputstream. Whichever the library offers
        }
    }
