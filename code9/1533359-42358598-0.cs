    public AudioClip tokenGrabClip;
    public AudioClip tokenReleaseClip;
    
    AudioSource      audioSrc;
    
    void Start () {
    
    	audioSrc = GetComponent<AudioSource> ();
    }
    
    public void PlayTokenGrabClip () {
    
        audioSrc.PlayOneShot (tokenGrabClip);
    }
    
    public void PlayTokenReleaseClip () {
    
        audioSrc.PlayOneShot (tokenReleaseClip);
    }
