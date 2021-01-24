    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            if (!vp.isPlaying)
            {
                Debug.Log("Resumed Playing");
                SmoothlyResumeOverTime(vp, 0.8f);
            }
        }
        else
        {
            if (!executingPause && vp.isPlaying)
            {
                Debug.Log("Paused Playing");
                SmoothlyPauseOverTime(vp, 0.8f);
            }
        }
    }
