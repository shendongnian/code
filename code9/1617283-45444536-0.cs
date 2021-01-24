    [ChildActionOnly]
    public ActionResult Notifications()
    {
        var notifications = // get the notifications;
        return PartialView("_Notifications", notifications);
    }
