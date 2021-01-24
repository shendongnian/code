    private bool Starting = false;
    public Image screen;
    float fadeTime = 3f;
    
    public void StartGame()
    {
        Starting = true;
        StartCoroutine(wait());
        screen.CrossFadeAlphaFixed(1, fadeTime, false);
    }
