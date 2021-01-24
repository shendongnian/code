        class Songs
        {
           public void songOne()
           {
               string name = "songOne";
               string path = "C:/songs/songone/
               playSong(path);
           }
           public void songOne()
           {
               string name = "songTwo";
               string path = "C:/songs/songtwo/
               playSong(path);
           }
           // And all the other songs
           public void playSong(string path)
           {
               WMPLib.WindowsMediaPlayer songPlayer = new WMPLib.WindowsMediaPlayer();
                songPlayer.URL = path;
                wplayer.Controls.Play();
           }
        }
