        private void uploadSongs(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var files = openFileDialog1.FileNames; //I also changed this line
                for (int i = 0; i < files.Length; i++)
                {
                    filelist.Items.Add(files[i]);
                }
            }
        }
        private void shuffleBttn_Click(object sender, EventArgs e)
        {
            ListBox.ObjectCollection list = filelist.Items;
            Random random = new Random();
            int w = list.Count;
            filelist.BeginUpdate();
            while (w > 1)
            {
                w--;
                int u = random.Next(w + 1);
                object value = list[u];
                list[u] = list[w];
                list[w] = value;
            }
            filelist.EndUpdate();
            filelist.Invalidate();
            WMPLib.IWMPPlaylist playlist = WMPPlayer.playlistCollection.newPlaylist("myplaylist");
            WMPLib.IWMPMedia media;
            foreach (object item in filelist.Items)
            {
                media = WMPPlayer.newMedia((string)item);
                playlist.appendItem(media);
            }
            WMPPlayer.currentPlaylist = playlist;
            WMPPlayer.Ctlcontrols.play();
         }
