    public bool CompressBitmap(string path, Bitmap bitmap)
    {
        try
        {
            var filestream = new FileStream(path, FileMode.Create);
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, filestream);
        }
        catch (Exception e)
        {
            // Show your custom dialog with report button and have access to the Exception message with e.Message, e.Stacktrace, etc.
        }
    }
