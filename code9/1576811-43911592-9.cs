    IEnumerator downloadImage()
    {
        string url = "http://wallpaper-gallery.net/images/hq-images-wallpapers/hq-images-wallpapers-12.jpg";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        DownloadHandler handle = www.downloadHandler;
        //Send Request and wait
        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            UnityEngine.Debug.Log("Error while Receiving: " + www.error);
        }
        else
        {
            UnityEngine.Debug.Log("Success");
            //Load Image
            Texture2D texture2d = DownloadHandlerTexture.GetContent(www);
            Sprite sprite = null;
            sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);
            if (sprite != null)
            {
                imageToUpdate.sprite = sprite;
            }
        }
    }
