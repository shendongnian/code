	private static bool ConnectToWifi(string profileName, WlanClient.WlanInterface wlanIface, Wifi wifi, string profile)
	{
		try
		{
			wlanIface.WlanConnectionNotification += Interface_ConnectionStateChanged;
			wlanIface.SetProfile(Wlan.WlanProfileFlags.AllUser, profile, true);
			wlanIface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Infrastructure, profileName);
			
			return true; //Just means the attempt was successful, not the connecting itself
		}
		catch (Exception e)
		{
			var ex = e;
			return false;
		}
	}     
	
	private static void Interface_ConnectionStateChanged(Wlan.WlanNotificationData notifyData, Wlan.WlanConnectionNotificationData connNotifyData)
	{
		// Do something with that info, be careful - might not be the same thread as before.
	}
