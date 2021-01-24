    public void Session_OnEnd()
    {
        Application.Lock();
        Application["UsersOnline"] = (int)Application["UsersOnline"] - 1;
        Application.UnLock();
    }
