    class Program
    {
        static void Main(string[] args)
        {
            var vlcService = new PlayerVLCService();
           
            vlcService.Play(new Uri("[YourPath].m3u8"));
            
            Console.ReadLine();
            vlcService.Stop();
		}
	}
	
	public class PlayerVLCService
    {
        private VlcMediaPlayer _vlcMediaPlayer;
        public PlayerVLCService()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            DirectoryInfo vlcLibDirectory;
            if (IntPtr.Size == 4)
                vlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\lib\x86\"));
            else
                vlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\lib\x64\"));
            _vlcMediaPlayer = new VlcMediaPlayer(vlcLibDirectory);
        }
		public void Play(Uri playPathUri)
        {
            _vlcMediaPlayer.SetMedia(playPathUri, null);
            _vlcMediaPlayer.Play();
        }
        public void Stop()
        {
            _vlcMediaPlayer.Stop();
        }
    }
