    private void AddSong()
    {
        List<Song> playlistSongs = new List<Song>(); //Set a list that holds values of your
                                                     //class' type. If you made a class
                                                     //called 'MyClass', your list would
                                                     //be List<MyClass> instead.
        playlistSongs.Add(new Song() { Favourite = false, Play = true, Name = "Song 1");
        //Add a new song to the list of songs. Each value in the class is represented
        //as above. You can change these values to be different, or even calculated
        //depending on variables.
        MyListView.ItemsSource = playlistSongs; //Finally, set each row's values in your
                                                //ListView equivalent to each entry
                                                //in your list created earlier.
    }
