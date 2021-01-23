    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView view = (ListView)sender;
            //Get Selected Item
            MusicLib song = view.SelectedItem as MusicLib;
            //code to play song from song.MusicPath
        }
