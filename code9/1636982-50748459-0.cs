    /// <summary>
    /// Used for debug
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    private string GetFirebaseMessageString(FirebaseMessage msg)
    {
        var builder = new StringBuilder();
        builder.AppendLine("############# Firebase Message #############");
        builder.AppendLine(string.Format("Message Id: {0}", msg.MessageId));
        builder.AppendLine(string.Format("Message Type: {0}", msg.MessageType));
        builder.AppendLine(string.Format("Priority: {0}", msg.Priority));
        builder.AppendLine(string.Format("From: {0}", msg.From));
        builder.AppendLine(string.Format("To: {0}", msg.To));
        builder.AppendLine(string.Format("Collapse Key: {0}", msg.CollapseKey));
        builder.AppendLine(string.Format("Error: {0}", msg.Error));
        builder.AppendLine(string.Format("Error Description: {0}", msg.ErrorDescription));
        builder.AppendLine(string.Format("Time To Live: {0}", msg.TimeToLive));
        builder.AppendLine(string.Format("Raw Data: {0}", msg.RawData));
        builder.AppendLine(string.Format("Notification Opened: {0}", msg.NotificationOpened));
        if (msg.Notification != null)
        {
            builder.AppendLine(string.Format(".Notification Title: {0}", msg.Notification.Title));
            builder.AppendLine(string.Format(".Notification Tag: {0}", msg.Notification.Tag));
            builder.AppendLine(string.Format(".Notification Body: {0}", msg.Notification.Body));
            builder.AppendLine(string.Format(".Notification ClickAction: {0}", msg.Notification.ClickAction));
            builder.AppendLine(string.Format(".Notification Sound: {0}", msg.Notification.Sound));
        }
        builder.AppendLine("############# End #############");
        return builder.ToString();
    }
