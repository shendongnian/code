    FileStream stream3 = new FileStream( "image2.tif", FileMode.Create );
    BitmapMetadata myBitmapMetadata = new BitmapMetadata( "tiff" );
    TiffBitmapEncoder encoder3 = new TiffBitmapEncoder();
    myBitmapMetadata.ApplicationName = "Microsoft Digital Image Suite 10";
    myBitmapMetadata.Author = new ReadOnlyCollection<string>( 
        new List<string>() { "Mehdi Daustany" } );
    myBitmapMetadata.CameraManufacturer = "Tailspin Toys";
    myBitmapMetadata.CameraModel = "TT23";
    myBitmapMetadata.Comment = "Nice Picture";
    myBitmapMetadata.Copyright = "2010";
    myBitmapMetadata.DateTaken = "5/23/2010";
    myBitmapMetadata.Keywords = new ReadOnlyCollection<string>( 
        new List<string>() { "Mehdi", "Daustany" } );
    myBitmapMetadata.Rating = 5;
    myBitmapMetadata.Subject = "Mehdi";
    myBitmapMetadata.Title = "Mehdi's photo";
    
    // Create a new frame that is identical to the one 
    // from the original image, except for the new metadata. 
    encoder3.Frames.Add( 
        BitmapFrame.Create( 
        decoder2.Frames[0], 
        decoder2.Frames[0].Thumbnail, 
        myBitmapMetadata, 
        decoder2.Frames[0].ColorContexts ) );
    
    encoder3.Save( stream3 );
    stream3.Close();
