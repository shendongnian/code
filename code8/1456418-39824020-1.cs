    private bool callCame = false;
    PhoneCallManager.CallStateChanged += PhoneCallManager_CallStateChanged;
    private async void PhoneCallManager_CallStateChanged(object sender, object e)
    {
        if (callCame&&(!PhoneCallManager.IsCallActive))
        {
            //do something
        }
        if (PhoneCallManager.IsCallIncoming)
        {
            callCame = true;
        }
    }
