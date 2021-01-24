    public Image imageToUpdate;
    void Start()
    {
        StartCoroutine(downloadImage());
    }
    IEnumerator downloadImage()
    {
        string authorization = authenticate("YourUserName", "YourPass");
        string url = "http://wallpaper-gallery.net/images/hq-images-wallpapers/hq-images-wallpapers-12.jpg";
        UnityWebRequest www = UnityWebRequest.Get(url);
        //www.SetRequestHeader("AUTHORIZATION", authorization);
        DownloadHandler handle = www.downloadHandler;
        //Send Request and wait
        yield return www.Send();
        if (www.isError)
        {
            UnityEngine.Debug.Log("Error while Receiving: " + www.error);
        }
        else
        {
            UnityEngine.Debug.Log("Success");
            //Load Image
            Texture2D texture2d = new Texture2D(8, 8);
            Sprite sprite = null;
            if (texture2d.LoadImage(handle.data))
            {
                sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);
            }
            if (sprite != null)
            {
                imageToUpdate.sprite = sprite;
            }
        }
    }
    string authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }
