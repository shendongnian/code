    List<Song> songs = songRepository.ReadSongs();
    PagedList<Song> pagedList = new PagedList<Song>(songs, page, pagesize); 
    var songartists = new List<Tuple<Song, Artist>> 
    foreach(var song in pagedList)
          songartists .Add(Tuple.Creeate(song, artistRepository.GetArtistBySongID(song.ID)));
    ViewData["songs"] = songartists ; 
