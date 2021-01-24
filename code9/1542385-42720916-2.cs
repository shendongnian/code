    using System;
    using UserNotifications;
    using MyApp _v1.AppInterfaces;
    using MyApp _v1.iOS.AppDependencies;
    using Foundation;
    using static CoreText.CTFontFeatureAllTypographicFeatures;
    [assembly: Xamarin.Forms.Dependency(typeof(LocalNotification))]
    namespace MyApp _v1.iOS.AppDependencies
    {
    public class LocalNotification : ILocalNotification
    {
        public void ShowNotification(string strNotificationTitle, 
                                    string strNotificationSubtitle, 
                                    string strNotificationDescription, 
                                    string strNotificationIdItem, 
                                    string strDateOrInterval, 
                                    int intervalType, 
                                    string extraParameters)
        {
            //intervalType: 1 - set to date | 2 - set to interval
            
            //Object creation.
            var notificationContent = new UNMutableNotificationContent();
            //Set parameters.
            notificationContent.Title = strNotificationTitle;
            notificationContent.Subtitle = strNotificationSubtitle;
            notificationContent.Body = strNotificationDescription;
            //notificationContent.Badge = 1;
            notificationContent.Badge = Int32.Parse(strNotificationIdItem);
            notificationContent.Sound = UNNotificationSound.Default;
            //Set date.
            DateTime notificationContentDate = Convert.ToDateTime(strDateOrInterval);
            NSDateComponents notificationContentNSCDate = new NSDateComponents();
            notificationContentNSCDate.Year = notificationContentDate.Year;
            notificationContentNSCDate.Month = notificationContentDate.Month;
            notificationContentNSCDate.Day = notificationContentDate.Day;
            notificationContentNSCDate.Hour = notificationContentDate.Hour;
            notificationContentNSCDate.Minute = notificationContentDate.Minute;
            notificationContentNSCDate.Second = notificationContentDate.Second;
            notificationContentNSCDate.Nanosecond = (notificationContentDate.Millisecond * 1000000);
            //Set trigger and request.
            var notificationRequestID = strNotificationIdItem;
            UNNotificationRequest notificationRequest = null;
            if (intervalType == 1)
            {
                var notificationCalenderTrigger = UNCalendarNotificationTrigger.CreateTrigger(notificationContentNSCDate, false);
		notificationRequest = UNNotificationRequest.FromIdentifier(notificationRequestID, notificationContent, notificationCalenderTrigger);
            }
            else
            {
                var notificationIntervalTrigger = UNTimeIntervalNotificationTrigger.CreateTrigger(Int32.Parse(strDateOrInterval), false);
 
                notificationRequest = UNNotificationRequest.FromIdentifier(notificationRequestID, notificationContent, notificationIntervalTrigger);
            }
            //Add the notification request.
            UNUserNotificationCenter.Current.AddNotificationRequest(notificationRequest, (err) =>
            {
                if (err != null)
                {
                    System.Diagnostics.Debug.WriteLine("Error : " + err);
                }
            });
        }
        
    }
    }
