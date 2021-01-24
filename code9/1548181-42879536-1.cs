    MovieTexture movieTexture;
    AudioSource vidAudio;
    public RawImage rawImage;
    
    void Start()
    {
        WWW www = new WWW("http://techslides.com/demos/sample-videos/small.ogv");
        movieTexture = www.GetMovieTexture();
        rawImage.texture = movieTexture;
    
        vidAudio = gameObject.AddComponent<AudioSource>();
        vidAudio.clip = movieTexture.audioClip;
    }
    
    void Update()
    {
        if (movieTexture.isReadyToPlay && !movieTexture.isPlaying)
        {
            movieTexture.Play();
            vidAudio.Play();
        }
    
        if (movieTexture.isPlaying)
        {
            rawImage.texture = movieTexture;
        }
    }
