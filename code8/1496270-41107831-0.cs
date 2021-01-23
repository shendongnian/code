    public Button playButton;
    
    public void playMovie(Action callback)
    {
        GetComponent<RawImage>().texture = myMovie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = myMovie.audioClip;
        myMovie.Play();
        audio.Play();
    
        StartCoroutine(FindEnd(callback));
    }
    
    
    private IEnumerator FindEnd(Action callback)
    {
        while (myMovie.isPlaying)
        {
            yield return 0;
        }
    
        callback();
        yield break;
    }
    
    void movieDonePlayingCallBack()
    {
    
    }
    
    void OnEnable()
    {
        //Register Button Event
        playButton.onClick.AddListener(() => buttonClickCallBack(playButton));
    
    }
    
    private void buttonClickCallBack(Button buttonPressed)
    {
        if (buttonPressed == playButton)
        {
            //Your code for when Play Button is clicked
            playMovie(movieDonePlayingCallBack);
        }
    }
    
    void OnDisable()
    {
        //Un-Register Button Event
        playButton.onClick.RemoveAllListeners();
    }
