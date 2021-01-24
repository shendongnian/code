    public class RecordAudioUWP : IRecordAudio
    {
        private MediaPlayerElement element;      
        private MediaPlayer player;
        public async Task<TimeSpan> SetSource(Stream _stream)
        {
            element = new MediaPlayerElement();
    
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var folder = await local.GetFolderAsync("Recordings");
            var file = await folder.GetFileAsync("MySound.MP3");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            element.Source = MediaSource.CreateFromStream(stream,"");
    
            player = element.MediaPlayer;
            MusicProperties properties = await
            file.Properties.GetMusicPropertiesAsync();
            TimeSpan myTrackDuration = properties.Duration;
            return myTrackDuration;
        }
    
        public void PlayAudio()
        {
            player.Play();
        }
    
        public void ForwardAudio()  
        {
            var session = player.PlaybackSession;
            session.Position += TimeSpan.FromSeconds(10);  
      
        }
    
        public void PauseAudio()
        {
            player.Pause();
        }
    
        public void RewindAudio() 
        {
            var session = player.PlaybackSession;
            session.Position -= TimeSpan.FromMinutes(1);
        }
    }
