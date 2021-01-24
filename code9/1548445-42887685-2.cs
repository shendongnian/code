    public  Bitmap CreateBitmapFromView(View view, bool autoScale = true)
        {
            var wasDrawingCacheEnabled = view.DrawingCacheEnabled;
            view.DrawingCacheEnabled = true;
            view.BuildDrawingCache(autoScale);
            view.DrawingCacheEnabled = wasDrawingCacheEnabled;
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filePath = System.IO.Path.Combine(sdCardPath, "test.png");
            var stream = new FileStream(filePath, FileMode.Create);
            bitmap2.Compress(Bitmap.CompressFormat.Png, 100, stream);
            return bitmap2;
        }
