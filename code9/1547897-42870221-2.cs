	public override void WillEnterForeground(UIApplication application)
	{
		var vc = UIApplication.SharedApplication?.KeyWindow?.RootViewController;
		while (vc != null)
		{
			NSNotificationCenter.DefaultCenter.PostNotificationName(Const.StartRefresh, new NSString("some custom data"));
			vc = vc.PresentedViewController;
		}
	}
