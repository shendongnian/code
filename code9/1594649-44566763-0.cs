        public class NotificationHubConnectionSettings : INotificationHubConnectionSettings
        {
            public NotificationHubClient Hub { get; set; }
            public NotificationHubConnectionSettings()
            {
                Hub = NotificationHubClient.CreateClientFromConnectionString(ConfigurationManager.AppSettings["Microsoft.Azure.NotificationHubs.ConnectionString"], ConfigurationManager.AppSettings["NotificationHub"]);
            }
        }
