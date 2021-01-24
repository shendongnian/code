    public class Notifications
        {
            private NotificationHub hub;
    
            public Notifications(string hubName, string listenConnectionString)
            {
                hub = new NotificationHub(hubName, listenConnectionString);
            }
            public async Task<Registration> StoreCategoriesAndSubscribe(IEnumerable<string> categories)
            {
                ApplicationData.Current.LocalSettings.Values["categories"] = string.Join(",", categories);
                return await SubscribeToCategories(categories);
            }
            public async Task<Registration> SubscribeToCategories(IEnumerable<string> categories = null)
            {
                var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
    
                if (categories == null)
                {
                    categories = RetrieveCategories();
                }
    
                // Using a template registration to support notifications across platforms.
                // Any template notifications that contain messageParam and a corresponding tag expression
                // will be delivered for this registration.
    
                const string templateBodyWNS = "<toast><visual><binding template=\"ToastText01\"><text id=\"1\">$(messageParam)</text></binding></visual></toast>";
    
                return await hub.RegisterTemplateAsync(channel.Uri, templateBodyWNS, "simpleWNSTemplateExample",
                        categories);
            }
            public IEnumerable<string> RetrieveCategories()
            {
                var categories = (string)ApplicationData.Current.LocalSettings.Values["categories"];
                return categories != null ? categories.Split(',') : new string[0];
            }
