    private static HttpClient client = new HttpClient();
    public async Task<Bitmap> loadAndDecodeBitmap(String uri) {        
        byte[] data = await client.GetByteArrayAsync(uri);
        Bitmap img = BitmapFactory.DecodeByteArray(data, 0, data.Length);
        return img;
    }
