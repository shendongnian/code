        private WMPLib.IWMPPlaylist openPlaylist(string playlistName)
        {
            WMPLib.IWMPPlaylist tempPlaylist = Player.newPlaylist(playlistName, null);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\playlists\\" + playlistName + ".cpt"))
            {
                while (sr.Peek() >= 0)
                {
                    string tempMediaUrl = sr.ReadLine();
                    WMPLib.IWMPMedia tempMedia = Player.newMedia(tempMediaUrl);
                    tempPlaylist.appendItem(tempMedia);
                }
                return tempPlaylist;
            }
        }
