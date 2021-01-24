    Admob.Instance().videoEventHandler += onInterstitialEvent;
        void onInterstitialEvent(string eventName, string msg)
        {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showRewardedVideo();
        }
        if(eventName==AdmobEvent.onAdFail){
        Debug.log(msg);
        }
    }
