    using NAudio.Wave;
    
    public sealed class SoundboardSingleton : IDisposable
    {
        private static readonly Lazy<SoundboardSingleton> lazy =
            new Lazy<SoundboardSingleton>(() => new SoundboardSingleton());
    
        public static SoundboardSingleton Instance { get { return lazy.Value; } }
    
        public IWavePlayer WaveOutDevice { get; set; }
        public AudioFileReader AudioFileReaderObj { get; set; }
        public float Volume { get; set; }
    
        private MediaCloser _mediaCloser;
        private Thread _mediaCloserThread;
        private StayAliveBot _liveBot;
        private Thread _botThread;
        
        public bool IsBusy { get; set; }
    
        private SoundboardSingleton()
        {
            // checks our NAudio WaveOutDevice playback for stop
            _mediaCloser = new MediaCloser();
            _mediaCloserThread = new Thread(_mediaCloser.CheckForStoppedPlayback);
            _mediaCloserThread.Start();
    
            // thread to play sound every 25 minutes, to avoid idle flag
            _liveBot = new StayAliveBot();
            _botThread = new Thread(_liveBot.Live);
            _botThread.Start();
        }
    
        public bool PlaySound(string filename)
        {
            // make sure we are not active
            if (IsBusy) { return false; }
    
            // process sound
            IsBusy = true;
            WaveOutDevice = new WaveOutEvent();
            AudioFileReaderObj = new AudioFileReader(filename);
            AudioFileReaderObj.Volume = Volume;
            WaveOutDevice.Init(AudioFileReaderObj);
            WaveOutDevice.Play();
    
            return true;
        }
    
        public void CloseWaveOut()
        {
            // clean up sound objects
            WaveOutDevice?.Stop();
    
            if (AudioFileReaderObj != null)
            {
                AudioFileReaderObj.Dispose();
                AudioFileReaderObj = null;
            }
            if (WaveOutDevice != null)
            {
                WaveOutDevice.Dispose();
                WaveOutDevice = null;
            }
        }
    
        public void Dispose()
        {
            if (_mediaCloserThread.IsAlive)
            {
                _mediaCloserThread.Abort();
            }
            if (_botThread.IsAlive)
            {
                _botThread.Abort();
            }
        }
    }
    
    public class MediaCloser
    {
        public void CheckForStoppedPlayback()
        {
            while (true)
            {
                // continuously check for our stopped playback state to cleanup
                Thread.Sleep(500);
                if (SoundboardSingleton.Instance.WaveOutDevice != null &&
                    SoundboardSingleton.Instance.WaveOutDevice.PlaybackState == PlaybackState.Stopped)
                {
                    SoundboardSingleton.Instance.CloseWaveOut();
                    SoundboardSingleton.Instance.IsBusy = false;
                }
            }
        }
    }
    
    public class StayAliveBot
    {
        public void Live()
        {
            while (true)
            {
                // prevent bot from going idle
                Thread.Sleep(1500000);
                if (!SoundboardSingleton.Instance.IsBusy)
                {
                    SoundboardSingleton.Instance.PlaySound(ConfigurationManager.AppSettings["SoundboardHeartbeatFile"]);
                }
            }
        }
    }
