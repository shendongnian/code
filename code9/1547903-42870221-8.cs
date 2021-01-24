	public override void DidEnterBackground(UIApplication application)
	{
		var vc = UIApplication.SharedApplication?.KeyWindow?.RootViewController;
		while (vc != null)
		{
			if (vc.RespondsToSelector(new Selector(Const.StopRefresh)))
				UIApplication.SharedApplication.SendAction(new Selector(Const.StopRefresh), vc, this, new UIEvent());
			vc = vc.PresentedViewController;
		}
	}
