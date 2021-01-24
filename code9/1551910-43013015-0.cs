    public Image imageToUpdate;
    void Start()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://wallpaper-gallery.net/images/hq-images-wallpapers/hq-images-wallpapers-12.jpg");
        request.Method = "GET";
        //request.ContentType = "image/png";
        //request.Headers.Add("Authorization", "Bearer " + AUTH_TOKEN);
        WebResponse response = request.GetResponse();
        if (response == null)
        {
            return;
        }
        //Download All the bytes
        byte[] bytes = downloadFullData(request);
        //Load Image
        Texture2D texture2d = new Texture2D(8, 8);
        Sprite sprite = null;
        if (texture2d.LoadImage(bytes))
        {
            sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);
        }
        if (sprite != null)
        {
            imageToUpdate.sprite = sprite;
        }
    }
    byte[] downloadFullData(HttpWebRequest request)
    {
        using (WebResponse response = request.GetResponse())
        {
            if (response == null)
            {
                return null;
            }
            using (Stream input = response.GetResponseStream())
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while (input.CanRead && (read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
        }
    }
