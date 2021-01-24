        struct Music 
    {
            public
                void PlaySong() {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = @"C:\Users\MyPC\Music\MoreMusic\songsample.wav";
                player.Load();
                player.Play();
            }
    }
    
