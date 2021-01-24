    IEnumerator StartSlide()
    {
        const float MAX_TIME = 2.0f; // time to wait before resetting the flag
        Slide = true;
        float timeNow = 0.0f;
        while ( timeNow < MAX_TIME && Slide )
        {
           timeNow += Time.deltaTime;
           yield return new WaitForEndOfFrame();
        }
        Slide = false;
    }
