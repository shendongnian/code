    public class MediaStuff
    {
        private bool _closing = false;
        public void PlayAudio(string audioFilePath)
        {
            var thread = new Thread(() => { PlayAudioThreadProc(audioFilePath); });
            thread.Start();
        }
        private void PlayAudioThreadProc(string audioFilePath)
        {
            MediaPlayer mediaPlayer = CreateMediaPlayer(audioFilePath);
            mediaPlayer.Play();
            while (!_closing)
            {
                System.Threading.Thread.Sleep(100);
                Application.DoEvents(); //This processes waiting event callbacks on a thread that's maintaining itself - Probably a better way to do this
            }
            mediaPlayer.Stop();
            mediaPlayer.MediaEnded -= MediaPlayer_MediaEnded;
            mediaPlayer.Close();
        }
        private MediaPlayer CreateMediaPlayer(string audioFilePath)
        {
            var mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;     //This event is not getting fired.
            mediaPlayer.Open(new Uri(Path.GetFullPath(audioFilePath)));
            return mediaPlayer;
        }
        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            //This part of code is supposed to start the media again after it is ended playing.
            var player = (MediaPlayer)sender;
            player.Position = TimeSpan.Zero;
            player.Play();
        }
        public void Stop()
        {
            _closing = true;
        }
    }
