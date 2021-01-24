    protected override void OnCreate(Bundle bundle)
    {
	  base.OnCreate(bundle);
	  SetContentView(....);
	  if (Intent != null) 
	  {
	   OnNewIntent(Intent);
	  }
    }
    protected override void OnNewIntent(Android.Content.Intent intent)
	{
	  base.OnNewIntent(intent);
      var appLinkData  = intent.GetStringExtra("al_applink_data");
	  AppLinkUrl alUrl = null;
	  if (appLinkData != null)
	  {
		alUrl = new Rivets.AppLinkUrl(intent.Data.ToString(), appLinkData);
	  }
      if (alUrl != null) {
       // LAUNCH URI
	  }
	}
