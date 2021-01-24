    var unAuthorizationOptions = UNAuthorizationOptions.Alert & UNAuthorizationOptions.Badge & UNAuthorizationOptions.Sound;
    var authReply = await UNUserNotificationCenter.Current.RequestAuthorizationAsync(unAuthorizationOptions);
    if (authReply.Item1 == true) // Xamarin.iOS does not label the tuple members ;-( (granted, error) 
    {
        var content = new UNMutableNotificationContent
        {
            Title = "Local Notification",
            Subtitle = "By SushiHangover",
            Body = "StackOverflow rocks",
            Badge = badgecount
        };
        var request = UNNotificationRequest.FromIdentifier("SushiHangover", content, null);
        await UNUserNotificationCenter.Current.AddNotificationRequestAsync(request);
    }
