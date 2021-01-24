    var userInfo = response.Notification.Request.Content.UserInfo;
				if (userInfo != null)
				{
					var value = userInfo.ValueForKey(mystring);
					if (userInfo.ContainsKey(new NSString(Constants.PushNotificationInfoKeys. NOTIFICATION_TYPE)))
					{
						//Do something here
					}
					Console.WriteLine("Value :" + value);
				}
