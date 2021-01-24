        try
        {
    
         string path = Path.Combine(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures).AbsolutePath, "newProdict.png");
         var fs = new FileStream(path, FileMode.Open);
            if (fs != null)
            {
                bitmapImg.Compress(Bitmap.CompressFormat.Png, 90, fs);
                fos.Close();
            }
        }
        catch (Exception ex) { }
