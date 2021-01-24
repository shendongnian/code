    public static Task<BitmapSource> GetNewImageAsync(Uri uri)
    {
        var tcs = new TaskCompletionSource<BitmapSource>();
        var bitmap = new BitmapImage(uri);
        if (bitmap.IsDownloading)
        {
            bitmap.DownloadCompleted += (s, e) => tcs.SetResult(bitmap);
            bitmap.DownloadFailed += (s, e) => tcs.SetResult(null);
        }
        else
        {
            tcs.SetResult(bitmap);
        }
        return tcs.Task;
    }
