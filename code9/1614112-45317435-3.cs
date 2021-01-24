    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    
        // Create your application here
        SetContentView(Resource.Layout.layout1);
    
        Button home = FindViewById<Button>(Resource.Id.home);
        home.Click += (sender, e) =>
        {
            FragmentTransaction transaction = this.FragmentManager.BeginTransaction();
            HomeFragment homefragment = new HomeFragment();
            transaction.Replace(Resource.Id.container, homefragment).Commit();
        };
    
        Button settings = FindViewById<Button>(Resource.Id.settings);
        settings.Click += (sender, e) =>
        {
            FragmentTransaction transaction = this.FragmentManager.BeginTransaction();
            SettingsFragment settingsfragment = new SettingsFragment();
            transaction.Replace(Resource.Id.container, settingsfragment).Commit();
        };
    }
