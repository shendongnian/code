    Bitmap bmp = null;
    try
    {
        using (var bmpFromFile = (Bitmap)Image.FromFile(file))
        {
            bmp = new Bitmap(bmpFromFile);
        }
        using (var g = Graphics.FromImage(bmp))
        {
            // Make changes to bmp.
        }
        // Save bmp to a temp file.
        // Delete the original file and move the temp file to that name.
    }
    finally
    {
        // Dispose bmp
        using (bmp) { }
    }
