    private bool Starting = false;
    public Image screen;
    float fadeTime = 3f;
    
    public void StartGame()
    {
        Starting = true;
    
        screen.CrossFadeAlphaWithCallBack(1f, fadeTime, delegate
        {
            Debug.Log("Done Fading");
            SceneManager.LoadScene(1);
        });
    }
