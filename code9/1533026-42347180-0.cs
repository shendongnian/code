    public void Login(Action success, Action<bool> failure)
    {
        if (!FB.IsInitialized)
        {
            Debug.Log("[FB] Not yet initialized. Will init again!");
            FB.Init(new InitDelegate(this.OnInitComplete), null, null);
            return;
        }
        new LoginWithReadPermissions(this.READ_PERMISSIONS, delegate
        {
            ServiceLocator.GetDB().SetBool("facebookBound", true, false);
            this.OnLoginCompleted(success, failure);
        }, delegate
        {
            failure(false);
        });
    }
