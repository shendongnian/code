    Coroutine pauseCoroutine;
    Coroutine resumeCoroutine;
    
    void SmoothlyPauseOverTime(VideoPlayer targetVp, float duration)
    {
        //Stop old coroutine before starting a new one
        if (pauseCoroutine != null)
            StopCoroutine(pauseCoroutine);
    
        pauseCoroutine = StartCoroutine(SmoothlyPauseOverTimeCOR(targetVp, duration));
    }
    
    void SmoothlyResumeOverTime(VideoPlayer targetVp, float duration)
    {
        //Stop old coroutine before starting a new one
        if (resumeCoroutine != null)
            StopCoroutine(resumeCoroutine);
    
        resumeCoroutine = StartCoroutine(SmoothlyResumeOverTimeCOR(targetVp, duration));
    }
