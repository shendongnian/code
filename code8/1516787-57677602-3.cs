    protected override void OnSessionChange(SessionChangeDescription changeDescription)
    {
        if (changeDescription.Reason == SessionChangeReason.SessionLogon)
        {
            // do work
        }
    }
