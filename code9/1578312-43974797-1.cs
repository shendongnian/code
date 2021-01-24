    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();
        SFBusyIndicator busyindicator = new SFBusyIndicator();
        this.AddSubview(busyindicator);
        busyindicator.AnimationType=SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeBattery;
        busyindicator.TextColor=UIColor.RED;
		busyindicator.ViewBoxHeight=20;
		busyindicator.ViewBoxWidth=20;
		busyindicator.IsBusy=True;
    }
