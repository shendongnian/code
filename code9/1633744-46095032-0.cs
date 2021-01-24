       protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            music = MediaPlayer.Create(this, Resource.Raw.bgsound);
            music.SetVolume(0.7f, 0.7f);
            music.Start();
            music.Looping = true;
        }
