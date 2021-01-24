    IEnumerator Start()
    {
    !UNITY_ADS // If the Ads service is not enabled...
        if (Advertisement.isSupported)
        { // If runtime platform is supported...
            Advertisement.Initialize(gameId, enableTestMode); // ...initialize.
        }
    if
    
        // Wait until Unity Ads is initialized,
        //  and the default ad placement is ready.
        while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }
    
        // Show the default ad placement.
        Advertisement.Show();
    }
