    //Raw Image to Show Video Images [Assign from the Editor]
    public RawImage image;
    //Video To Play [Assign from the Editor]
    public VideoClip videoToPlay;
    
    private VideoPlayer vp;
    private VideoSource videoSource;
    
    //Audio
    private AudioSource aS;
    
    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }
    
    IEnumerator playVideo()
    {
        //Add VideoPlayer to the GameObject
        vp = gameObject.AddComponent<VideoPlayer>();
    
        //Add AudioSource
        aS = gameObject.AddComponent<AudioSource>();
    
        //Disable Play on Awake for both Video and Audio
        vp.playOnAwake = false;
        aS.playOnAwake = false;
    
        //We want to play from video clip not from url
        vp.source = VideoSource.VideoClip;
    
        //Set Audio Output to AudioSource
        vp.audioOutputMode = VideoAudioOutputMode.AudioSource;
    
        //Assign the Audio from Video to AudioSource to be played
        vp.EnableAudioTrack(0, true);
        vp.SetTargetAudioSource(0, aS);
    
        //Set video To Play then prepare Audio to prevent Buffering
        vp.clip = videoToPlay;
        vp.Prepare();
    
        //Wait until video is prepared
        while (!vp.isPrepared)
        {
            Debug.Log("Preparing Video");
            yield return null;
        }
    
        Debug.Log("Done Preparing Video");
    
        //Assign the Texture from Video to RawImage to be displayed
        image.texture = vp.texture;
    }
