    MovieTexture myMoviePlayerTexture;
    void Start()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "test.ogv");
    
        WWW www = new WWW("file:///" + filePath);
        Renderer r = GetComponent<Renderer>();
        myMoviePlayerTexture = www.GetMovieTexture();
    
        r.material.mainTexture = myMoviePlayerTexture;
    }
    
    void Update()
    {
        if (myMoviePlayerTexture.isReadyToPlay && !myMoviePlayerTexture.isPlaying)
        {
            myMoviePlayerTexture.Play();
        }
    }
