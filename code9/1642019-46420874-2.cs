    public Light lightToFade;
    public float eachFadeTime = 2f;
    public float fadeWaitTime = 5f;
    
    void Start()
    {
        StartCoroutine(fadeInAndOutRepeat(lightToFade, eachFadeTime, fadeWaitTime));
    }
