	protected override void OnNewIntent(Intent intent)
	{
		base.OnNewIntent(intent);
        NotificationClickedOn(intent);
	}
