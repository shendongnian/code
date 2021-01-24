    IEnumerator LoadImages()
    {
        int oldImgIndx = imageIndex;
        imageIndex = 1;
 
        bool thereAreImages = true;
        while (thereAreImages && imageIndex < 1000)
        {
            if (System.IO.File.Exists(CreateFilePath(imageIndex)))
            {
                string url = "File:///" + CreateFilePath(imageIndex);
                Texture2D tex = new Texture2D(4, 4);
                WWW www = new WWW(url);
                yield return www;
                www.LoadImageIntoTexture(tex);
                spriteList.Add(Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f)));
                imageIndex++;
            }
            else
            {
                thereAreImages = false;
            }
        }
        finished = true;
        imageIndex = oldImgIndx;
    }
