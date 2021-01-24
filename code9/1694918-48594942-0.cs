    var wb = new WriteableBitmap(100, 100);                        
    byte[] imageArray = new byte[100 * 100 * 4];
    for (int i = 0; i < imageArray.Length; i += 4)
    {
        //BGRA format
        imageArray[i] = 0; // Blue
        imageArray[i + 1] = 0;  // Green
        imageArray[i + 2] = 255; // Red
        imageArray[i + 3] = 255; // Alpha
    }
                
    using (Stream stream = wb.PixelBuffer.AsStream())
    {
        //write to bitmap
        await stream.WriteAsync(imageArray, 0, imageArray.Length);
    }
    TargetImage.Source = wb;
