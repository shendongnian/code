    public override UIWindow Window { get; set; }
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new UIViewController();
            Window.MakeKeyAndVisible();
            Forms.Init();
            InitNotifications(app, options);
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
