    public partial class MediaPlayer : ContentPage
      {
         private IPlaybackController PlaybackController => 
       CrossMediaManager.Current.PlaybackController;
   
        public MediaPlayer()
        {
            InitializeComponent();
            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                ProgressBar.Progress = e.Progress;
                Duration.Text = "" + e.Duration.TotalSeconds.ToString() + " 
         seconds";
            };
        }
        void PlayClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Play();
        }
        void PauseClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Pause();
        }
        void StopClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Stop();
        }
      }
