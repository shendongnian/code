    Coroutine pauseCoroutine;
    Coroutine resumeCoroutine;
    
    bool executingPause = false;
    
    void SmoothlyPauseOverTime(VideoPlayer targetVp, float duration)
    {
        //Stop old coroutines before starting a new one
        if (pauseCoroutine != null)
            StopCoroutine(pauseCoroutine);
    
        if (resumeCoroutine != null)
            StopCoroutine(resumeCoroutine);
    
    
        executingPause = true;
        pauseCoroutine = StartCoroutine(SmoothlyPauseOverTimeCOR(targetVp, duration));
    }
    
    void SmoothlyResumeOverTime(VideoPlayer targetVp, float duration)
    {
        if (pauseCoroutine != null)
            StopCoroutine(pauseCoroutine);
    
        //Stop old coroutines before starting a new one
        if (resumeCoroutine != null)
            StopCoroutine(resumeCoroutine);
    
        resumeCoroutine = StartCoroutine(SmoothlyResumeOverTimeCOR(targetVp, duration));
    }
