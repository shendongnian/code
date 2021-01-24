            public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            CrossPushNotification.Initialize<CrossPushNotificationListener>();
            return base.FinishedLaunching(app, options);
        }
