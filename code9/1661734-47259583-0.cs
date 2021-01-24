    public class MainActivity : Activity
    {
        MediaPlayer _player;
        Button playButton;
        Button playButton1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            playButton = FindViewById<Button>(Resource.Id.playButton);
            playButton.Click += PlayButton_Click;
            playButton = FindViewById<Button>(Resource.Id.playButton1);
            playButton.Click += PlayButton1_Click;
            void PlayButton_Click(object sender, System.EventArgs e)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.mysound);
                _player.Start();
            }
            void PlayButton1_Click(object sender, System.EventArgs e)
            {
                // Second Button
                _player = MediaPlayer.Create(this, Resource.Raw.A);
                _player.Start();
            }
        }
    }
