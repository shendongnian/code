    protected override void OnCreate(Bundle bundle)
    {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide();
            //AdMob
            mAdView = (AdView)FindViewById<AdView>(Resource.Id.adView);
            AdRequest adRequest = new AdRequest.Builder().Build();
            mAdView.LoadAd(adRequest);
            //AdMob
    }
