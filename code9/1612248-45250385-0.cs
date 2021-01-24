    public class PlaybackService
    {
        private static PlaybackService instance;
        public static PlaybackService Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlaybackService();
                return instance;
            }
        }
        public MediaPlayer Player { get; private set; }
        public PlaybackService()
        {
            // Create the player instance
            Player = new MediaPlayer();
            
        }
    }
