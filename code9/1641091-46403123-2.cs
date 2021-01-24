        private static readonly object syncObj = new object(); 
        public MediaPlayer GetInstance()
        {
            lock (syncObj)
            {
                if (mediaPlayer == null)
                {
                    mediaPlayer = new MediaPlayer();
                    mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
                }
            }
            return mediaPlayer;
        }
    
