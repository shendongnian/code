    public void playItem(ItemsPool it) 
        {
            player.CreateControl();
            player.Enabled = true;
            player.enableContextMenu = false;
            player.uiMode = "none";
            player.Name = "player";
            player.Anchor = AnchorStyles.Left |  AnchorStyles.Right | AnchorStyles.Bottom;
            WMPLib.IWMPMedia media; 
            WMPLib.IWMPPlaylist playlist = player.playlistCollection.newPlaylist("myplaylist"); 
            for (int x = 0; x < it.count; x++) 
             { 
                media = player.newMedia(it.getItem(x).video); 
             playlist.appendItem(media);  
            } 
            player.currentPlaylist = playlist;
            if (p_onset)
            { player.Ctlcontrols.play(); }
           else
            {
                if (!Vars.playOne)
              { PlayNext(); }
             }
            }
