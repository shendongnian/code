    private void SqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
        if (e.Info == SqlNotificationInfo.Insert)
        {
             RecordInfo info = GetLastInsertedRecord(); //Just a custom entity
              if(info.UserId > 0)
                 NotificationHub.SendNotification(info.UserId);
        }
        RegisterNotification(DateTime.Now);
    }
