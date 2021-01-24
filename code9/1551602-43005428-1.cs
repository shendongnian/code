        int queueSize = 0;
        int queueCurrent = 0;
        List<Song> toPlay = new List<Song>();
        class Manager
        {
            public void addSong(Song add)
            {
                toPlay.add(add);
                queueSize++;
            }
            public void removeSong(int remove)
            {
                toPlay.RemoveAt(remove)
                queueSize--;
            }
            public void playSong(int index)
            {
                Song play = toPlay[index]
                WMPLib.WindowsMediaPlayer songPlayer = new WMPLib.WindowsMediaPlayer();
                songPlayer.URL = play.FilePath;
                wplayer.Controls.Play();
            }
        }
        class Song
        {
            string FilePath;
            string Name;
            int Index;
            public Song(string name, int index)
            {
                Name = name;
                Index = index;
            }
        }
