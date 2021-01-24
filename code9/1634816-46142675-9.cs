    public async Task SetModel(ArticleTeaser model) {
        title.SetText(model.promotionContent.title.value, TextView.BufferType.Normal);
        description.SetText(model.promotionContent.description.value, TextView.BufferType.Normal);
        try {
            var uri = Android.Net.Uri.Parse(model.promotionContent.imageAsset.urls[0].url);
            Log.Debug(TAG, "Image " + (++ctr) + " load starting...");
            await LoadAsync(model.promotionContent.imageAsset.GetUrlWithMinHeight(240), image);
            Log.Debug(TAG, "Image " + ctr + " load completed");
        } catch (Exception ex) {
            Log.Debug(TAG, ex.Message);
        }
    }
    static ImageSvc imgSvc = new ImageSvc(); //should consider injecting service
    private async Task<Image> LoadAsync(String uri, ImageView image) {
        Bitmap bitmap = await imgSvc.loadAndDecodeBitmap(uri);
        image.SetImageBitmap(bitmap);
    }
    
    //Use only one shared instance of `HttpClient` for the life of the application
    private static HttpClient client = new HttpClient();
    public async Task<Bitmap> loadAndDecodeBitmap(String uri) {        
        byte[] data = await client.GetByteArrayAsync(uri);
        Bitmap img = BitmapFactory.DecodeByteArray(data, 0, data.Length);
        return img;
    }
