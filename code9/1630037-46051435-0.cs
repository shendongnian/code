            public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, System.Action<UIBackgroundFetchResult> completionHandler)
    		{
    			base.DidReceiveRemoteNotification(application, userInfo, completionHandler);
    			if (application.ApplicationState == UIApplicationState.Active)
    			{
    				//app is currently active, you can get your payload (userInfo) data here
    			}
    			else if (application.ApplicationState == UIApplicationState.Background)
    			{
    				//app is in background, you can get your payload (userInfo)
    			}
    			else if (application.ApplicationState == UIApplicationState.Inactive)
    			{
    				//app is transitioning from background to foreground (user taps notification), do what you need when user taps here, you can get your payload (userInfo)
    			}
    		}
