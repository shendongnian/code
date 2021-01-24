        DirectoryInfo di = new DirectoryInfo("C:/Users/USER/MyMusic");
        FileInfo[] Files = di.GetFiles("*.mp3"); //Getting mp3 files
        var songs = new ObservableCollection<Song>();
        foreach (FileInfo file in Files)
        {
            string fileName = file.FullName;
            TagLib.File tagFile = TagLib.File.Create(fileName);
            title = tagFile.Tag.Title;
            artist = tagFile.Tag.FirstAlbumArtist;
            album = tagFile.Tag.Album;
            year = tagFile.Tag.Year;
            genre = tagFile.Tag.FirstGenre;
            //string duration = tagFile.Tag.time;
            songs.Add(new Song { Name = title, Artist = artist, Album = album, Year = year, Genre = genre });
        }
        return songs;
