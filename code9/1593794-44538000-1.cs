    private void playMusic_Click(object sender, RoutedEventArgs e)
    {
    
    
        if (MylistBox.SelectedItem==null)
        {
            Song[] songname =
            {
                new Song
                {
                    Name = "item1",
                    Source = new Uri("ms-appx:///Assets/24K Magic.mp3")
                },
                new Song
                {
                    Name = "item2",
                    Source = new Uri("ms-appx:///Assets/Summer Air.mp3")
                },
                new Song
                {
                    Name = "item3",
                    Source = new Uri("ms-appx:///Assets/Vampire.mp3")
                },
                new Song
                {
                    Name = "item4",
                    Source = new Uri("ms-appx:///Assets/Happy.mp3")
                }
            };
            MylistBox.SelectedItem = songname[new Random().Next(0,songname.Length)];  
        }
        mediaElement_music.Source = ((Song)MylistBox.SelectedItem).Source; 
    }
