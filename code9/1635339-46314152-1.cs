    public ActionResult Notifications()
    {
        NotificationsModule.messageBL = _messageBL;
        long UserID = GetCurrentUser();
        Notification _Notification = new Notification();
        _Notification.GetToken = SignalRConnections.GetToken(UserID);
        _Notification.UserAgent = cryptClass.crypt.Encrypt(Request.UserAgent.ToLower());
        _Notification.IP = cryptClass.crypt.Encrypt(Request.UserHostAddress);
        return View(_Notification);
    }
