    System.IO.Stream outputStream = null;
    
    var renderer = new Xamarin.Forms.Platform.Android.StreamImagesourceHandler ();
    Bitmap photo = await renderer.LoadImageAsync (img, Forms.Context);
    var savedImageFilename = System.IO.Path.Combine (directory, filename);
    
    System.IO.Directory.CreateDirectory(directory);
    
    bool success = false;
    using (outputStream = new System.IO.FileStream(savedImageFilename, System.IO.FileMode.Create))
    {
        if (System.IO.Path.GetExtension (filename).ToLower () == ".png")
            success = await photo.CompressAsync(Bitmap.CompressFormat.Png, 100, outputStream);
        else
            success = await photo.CompressAsync(Bitmap.CompressFormat.Jpeg, 100, outputStream);
    }
