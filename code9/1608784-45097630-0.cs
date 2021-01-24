	private static void ConnectToWifi(string profileName, WlanClient.WlanInterface wlanIface, Wifi wifi, string profile)
	{
		new Thread(()=>{
		
			bool result = false;
			
			try
			{
				wlanIface.SetProfile(Wlan.WlanProfileFlags.AllUser, profile, true);
				wlanIface.ConnectSynchronously(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Infrastructure, profileName, 5000);
				var status = wifi.ConnectionStatus;
				var x = wlanIface.GetProfileXml(profileName);
				
				result = (status != WifiStatus.Disconnected);
			}
			catch (Exception e)
			{
				var ex = e;
			}
			finally
			{
				Dispatcher.BeginInvoke(new Action(()=>{WhateverYouDoWithYourResult(result);}));
			}
		
		}).Start();
	}     
