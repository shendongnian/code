    private Action<bool> _onAdReady;
    
    private void RequestInterstitialWithCallbak(Action<bool> onAdReady)
    {
        _onAdReady = onAdReady;
        interstitial = new InterstitialAd("ca-app-pub-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        interstitial.OnAdLoaded += HandleInterstitialLoaded;
        interstitial.LoadAd(new AdRequest.Builder().Build());
    
        _onAdReady?.Invoke(true); //???????????
    }
    
    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleInterstitialLoaded event received.");
        _onAdReady?.Invoke(true); //???????????
    }
