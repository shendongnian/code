    // Configuration (NOTE: .pfx can also be used here)
    var config = new ApnsConfiguration (ApnsConfiguration.ApnsServerEnvironment.Sandbox, 
        "push-cert.p12", "push-cert-pwd");
    
    // Create a new broker
    var apnsBroker = new ApnsServiceBroker (config);
        
    // Wire up events
    apnsBroker.OnNotificationFailed += (notification, aggregateEx) => {
    
    	aggregateEx.Handle (ex => {
    	
    		// See what kind of exception it was to further diagnose
    		if (ex is ApnsNotificationException) {
    			var notificationException = (ApnsNotificationException)ex;
    			
    			// Deal with the failed notification
    			var apnsNotification = notificationException.Notification;
    			var statusCode = notificationException.ErrorStatusCode;
    
    			Console.WriteLine ($"Apple Notification Failed: ID={apnsNotification.Identifier}, Code={statusCode}");
    	
    		} else {
    			// Inner exception might hold more useful information like an ApnsConnectionException			
    			Console.WriteLine ($"Notification Failed for some unknown reason : {ex.InnerException}");
    		}
    
    		// Mark it as handled
    		return true;
    	});
    };
    
    apnsBroker.OnNotificationSucceeded += (notification) => {
    	Console.WriteLine ("Apple Notification Sent!");
    };
    
    // Start the broker
    apnsBroker.Start ();
    
    foreach (var deviceToken in MY_DEVICE_TOKENS) {
    	// Queue a notification to send
    	apnsBroker.QueueNotification (new ApnsNotification {
    		DeviceToken = deviceToken,
    		Payload = JObject.Parse ("{\"aps\":{\"alert\":\"" + "Hi,, This Is a Sample Push Notification For IPhone.." + "\",\"badge\":1,\"sound\":\"default\"}}")
    	});
    }
       
    // Stop the broker, wait for it to finish   
    // This isn't done after every message, but after you're
    // done with the broker
    apnsBroker.Stop ();
