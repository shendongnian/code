    public MeshRenderer imageToDisplay;
    string url = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Google_2015_logo.svg/408px-Google_2015_logo.svg.png";
    void Start()
    {
        StartCoroutine(loadSpriteImageFromUrl(url));
    }
    IEnumerator loadSpriteImageFromUrl(string URL)
    {
        WWW www = new WWW(URL);
        while (!www.isDone)
        {
            Debug.Log("Download image on progress" + www.progress);
            yield return null;
        }
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download failed");
        }
        else
        {
            Debug.Log("Download succes");
            Texture2D texture = new Texture2D(1, 1);
            www.LoadImageIntoTexture(texture);
            imageToDisplay.material.mainTexture = texture;
        }
    }
