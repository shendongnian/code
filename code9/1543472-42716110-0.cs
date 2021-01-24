    string xml = @"
        <toast>
          <visual>
            <binding template='ToastGeneric'>
              <text>Microsoft Company Store</text>
              <text>New Halo game is back in stock!</text>
            </binding>
          </visual>
        </toast>";
    
    var content = new Windows.Data.Xml.Dom.XmlDocument();
    content.LoadXml(xml);
    
    var deliveryTime = DateTimeOffset.Now.AddSeconds(5);
    
    var toast = new ScheduledToastNotification(content, deliveryTime);
    
    ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
