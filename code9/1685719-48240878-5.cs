    Coroutine pauseCoroutine;
    Coroutine resumeCoroutine;
    
    void SmoothlyPauseOverTime(VideoPlayer targetVp, float duration)
    {
        //Stop old coroutines before starting a new one
        if (pauseCoroutine != null)
            StopCoroutine(pauseCoroutine);
    
        if (resumeCoroutine != null)
            StopCoroutine(resumeCoroutine);
    
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
