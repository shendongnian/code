    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
            ImageCircleRenderer.Init();
            TintedImageRenderer.Init();
            FloatingActionButtonRenderer.InitControl();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
