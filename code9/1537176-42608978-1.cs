    [BeforeFeature]
    public static void Before()
    {
        AndroidApp app;
        Console.WriteLine("** [BeforeFeature]");
        app = ConfigureApp
            .Android
            // TODO: Update this path to point to your Android app and uncomment the
            // code if the app is not included in the solution.
            .ApkFile(<Path to APK>)
            .StartApp();
        FeatureContext.Current.Add("App", app);
    }
