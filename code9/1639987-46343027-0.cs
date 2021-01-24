    protected override void OnCreate(Bundle bundle)
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;
    
                base.OnCreate(bundle);
    
                global::Xamarin.Forms.Forms.Init(this, bundle);            
                LoadApplication(new App());
                Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 0, 0, 0)); //here
            }
