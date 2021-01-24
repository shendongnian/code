    protected override void OnCreate(Bundle bundle)
          {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            VideoViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            FileAccessHelper.CopyDatabaseIfNotExists("BizQuiz");
            LoadApplication(new App());
          }
 
