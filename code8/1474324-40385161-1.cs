    WebCamTexture webCam = new WebCamTexture (160, 120);
    webCam.play();
    Texture2D originalFeedTexture = new Texture2D(webCam.width, webCam.height);
    originalFeedTexture.SetPixels(webCam.GetPixels());
    originalFeedTexture.Apply();
    ///Use it  then destroy it
    Object.Destroy(originalFeedTexture);
