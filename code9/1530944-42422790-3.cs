    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        LoadApplication(new Origination.App ());
        NotificationManager.Initialize<NotificationListener>();
        return base.FinishedLaunching(app, options);
    }
    
    public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
    {
        // Get current device token
        var DeviceToken = deviceToken.Description;
        if (!string.IsNullOrWhiteSpace(DeviceToken))
        {
            DeviceToken = DeviceToken.Trim('<').Trim('>').Replace(" ", "");
        }
    
        // Get previous device token
        var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey(NotificationKeys.TokenKey);
    
        // Has the token changed?
        if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(DeviceToken))
        {
            NotificationManager.Listener.OnRegister(DeviceToken);
        }
    
        // Save new device token 
        NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, NotificationKeys.TokenKey);
        NSUserDefaults.StandardUserDefaults.Synchronize();
    
    }
    
    public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
    {
        HandleNotification(userInfo);
    }
    
    public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
    {
        HandleNotification(userInfo);
    }
    
    #region Handle Notification
    
    private static string DictionaryToJson(NSDictionary dictionary)
    {
        NSError error;
        var json = NSJsonSerialization.Serialize(dictionary, NSJsonWritingOptions.PrettyPrinted, out error);
        return json.ToString(NSStringEncoding.UTF8);
    }
    
    public void HandleNotification(NSDictionary userInfo)
    {
        var parameters = new Dictionary<string, object>();
        var json = DictionaryToJson(userInfo);
        JObject values = JObject.Parse(json);
    
        var keyAps = new NSString("aps");
    
        if (userInfo.ContainsKey(keyAps))
        {
            NSDictionary aps = userInfo.ValueForKey(keyAps) as NSDictionary;
    
            if (aps != null)
            {
                foreach (var apsKey in aps)
                {
                    parameters.Add(apsKey.Key.ToString(), apsKey.Value);
                    JToken temp;
                    if (!values.TryGetValue(apsKey.Key.ToString(), out temp))
                        values.Add(apsKey.Key.ToString(), apsKey.Value.ToString());
                }
            }
        }
    
        NotificationManager.Listener.OnMessage(values);
    }
    
    #endregion
