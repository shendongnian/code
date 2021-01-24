        public class MainActivity : Activity
        {
            Button playButton;
            Button pauseButton;
            Button stopButton;
            SeekBar seekBar;
            Android.Media.MediaPlayer player;
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                player = Android.Media.MediaPlayer.Create(this, Resource.Raw.hello);
    
                playButton = FindViewById<Button>(Resource.Id.play);
                pauseButton = FindViewById<Button>(Resource.Id.pause);
                stopButton = FindViewById<Button>(Resource.Id.stop);
    
                playButton.Click += OnPlayClick;
                pauseButton.Click += OnPauseClick;
                stopButton.Click += OnStopClick;
    
               
    
                seekBar = FindViewById<SeekBar>(Resource.Id.myseekBar);
            }
    
            
    
            private void OnPlayClick(object sender, System.EventArgs e)
            {
    
                player.Start();
                seekBar.Max = player.Duration;
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 10;
                timer.Elapsed += OnTimedEvent;
                timer.Enabled = true;
            }
    
            private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
            {
                seekBar.Progress = player.CurrentPosition;
            }
    
            private void OnPauseClick(object sender, System.EventArgs e)
            {
                player.Pause();
            }
    
            private void OnStopClick(object sender, System.EventArgs e)
            {
                player.Stop();
                player.Prepare();
                player.SeekTo(0);
            }
        }
    }
