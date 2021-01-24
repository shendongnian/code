    var notify = new NotifyIcon();
    notify.Visible = true;
    notify.Icon = System.Drawing.SystemIcons.Information;
    notify.ShowBalloonTip(3000, "Title", "TextBody", ToolTipIcon.Info)
    //3000 is in milliseconds
