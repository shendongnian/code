        public class playr
    {
        private Queue<string> playlist;
        public static IWavePlayer player = new WaveOutEvent();
        // private WaveStream fileWaveStream;
        public playr()
        {
        }
        public playr(List<string> startingPlaylist)
        {
            playlist = new Queue<string>(startingPlaylist);
        }
        public void PlaySong()
        {
            if (playlist.Count < 1)
            {
                return;
            }
            if (player != null && player.PlaybackState != PlaybackState.Stopped)
            {
                player.Stop();
            }
            if (player != null)
            {
                player.Dispose();
                player = null;
            }
            player = new WaveOutEvent();
            var audioFilePath = playlist.First();
            var fileWaveStream = new AudioFileReader(audioFilePath);
            player.Init(fileWaveStream);
            player.Play();
            player.PlaybackStopped += (sender, evn) => { PlaySong(); };
        }
    }
