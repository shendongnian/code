    namespace MyApp _v1.AppInterfaces
    {
    public interface ILocalNotification
    {
        //void ShowNotification(string strTitle, string strDescription, string idNotification, string strURL);
        void ShowNotification(string strNotificationTitle, 
            string strNotificationSubtitle, 
            string strNotificationDescription, 
            string strNotificationIdItem, 
            string strDateOrInterval, 
            int intervalType, 
            string extraParameters);
    }
    }
