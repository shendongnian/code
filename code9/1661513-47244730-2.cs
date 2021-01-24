    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        // Set our view from the "main" layout resource
        SetContentView (Resource.Layout.Main);
        Button buttonCmdWelfare = FindViewById<Button> (Resource.Id.cmdWelfare);
        buttonCmdWelfare.Click += delegate {
            //Clicked
        };
        Button buttonCmdSettings = FindViewById<Button> (Resource.Id.cmdSettings);
        buttonCmdSettings.Click += delegate {
            //Clicked
        };
    }
