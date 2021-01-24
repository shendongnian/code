    public void Login(Action success, Action<bool> failure)
        {
            Action successAction = () =>
            {
                ServiceLocator.GetDB().SetBool("facebookBound", true, false);
                this.OnLoginCompleted(success, failure);
            };
            Action failureAction = () =>
            {
                failure(false);
            };
            if (!FB.IsInitialized)
            {
                Debug.Log("[FB] Not yet initialized. Will init again!");
                FB.Init(new InitDelegate(this.OnInitComplete), null, null);
                return;
            }
            new LoginWithReadPermissions(this.READ_PERMISSIONS, successAction, failureAction);
        }
