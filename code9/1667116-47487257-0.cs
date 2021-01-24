        private void ScheduleToast(DateTime scheduledTime)
        {
            const string TOAST = @"
                        <toast>
                          <visual>
                            <binding template=""ToastTest"">
                              <text>Hello Toast</text>
                            </binding>
                          </visual>
                          <audio src =""ms-winsoundevent:Notification.Mail"" loop=""true""/>
                        </toast>";
            Windows.Data.Xml.Dom.XmlDocument xml = new Windows.Data.Xml.Dom.XmlDocument();
            xml.LoadXml(TOAST);
            ScheduledToastNotification toast = new ScheduledToastNotification(xml, scheduledTime);
            toast.Id = "IdTostone" + scheduledTime.ToString();
            toast.Tag = "NotificationOne";
            toast.Group = "MyEverydayToasts";
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
        }
        private void RescheduleToastsForTheNextDays(int nDays = 30, TimeSpan timeOfDay)
        {
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();
            IReadOnlyList<ScheduledToastNotification> scheduledToasts = toastNotifier.GetScheduledToastNotifications();
            foreach(ScheduledToastNotification toast in scheduledToasts)
                toastNotifier.RemoveFromSchedule(toast);
            for (int i=0; i<nDays; i++)
            {
                DateTime scheduledTime = DateTime.Today + timeOfDay + TimeSpan.FromDays(i);
                if (scheduledTime > DateTime.Now)
                    ScheduleToast(scheduledTime);
            }
        }
