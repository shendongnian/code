    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView view = (ListView)sender;
            //Get Selected Item
            MusicLib song = view.SelectedItem as MusicLib;
            string path = song.MusicPath;
            //code to play song from song.MusicPath
            MediaElement player = new MediaElement();
            player.Source = MediaSource.CreateFromUri(new Uri(path));
            player.Play();
            //can then control the playback of the song through the player object then
        }
