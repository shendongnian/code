    public Bitmap CreateBitmapFromView(View view, bool autoScale = true)
    {
        var wasDrawingCacheEnabled = view.DrawingCacheEnabled;
        view.DrawingCacheEnabled = true;
        view.BuildDrawingCache(autoScale);
        var bitmap = view.GetDrawingCache(autoScale);
        view.DrawingCacheEnabled = wasDrawingCacheEnabled;
        return bitmap;
    }
