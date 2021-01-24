        private object syncObj;
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
    
