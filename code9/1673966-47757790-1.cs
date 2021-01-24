	void NotificationClickedOn(Intent intent)
	{
		if (intent.Action == "ASushiNotification" && intent.HasExtra("MessageFromSushiHangover"))
		{
			/// Do something now that you know the user clicked on the notifcation...
			var notificationMessage = intent.Extras.GetString("MessageFromSushiHangover");
			var winnerToast = Toast.MakeText(this, $"{notificationMessage}.\n\n Please send 2 BitCoins to SushiHangover to process your winning ticket! ", ToastLength.Long);
			winnerToast.SetGravity(Android.Views.GravityFlags.Center, 0, 0);
			winnerToast.Show();
		}
	}
