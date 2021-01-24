    void OnImageLoad(string imgPath, Texture2D tex, ImageAndVideoPicker.ImageOrientation imgOrientation)
    {
        Debug.Log("Image Location : " + imgPath);
        Debug.Log("Image Loaded : " + imgPath);
        string url = QRCodeDecodeController.DecodeByStaticPic(duplicateTexture(tex));
        StartCoroutine(GetSceneAndLoadLevel(url));
    }
