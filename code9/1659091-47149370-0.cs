    public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
        global::Xamarin.Forms.Forms.Init();
        CarouselViewRenderer.Init();   //Add this line.
        LoadApplication(new App());
        return base.FinishedLaunching(app, options);
    }
