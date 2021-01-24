    List<Artist> artists = new List<Artist>();
    List<Song> songs = songRepository.ReadSongs();
    PagedList<Song> pagedList = new PagedList<Song>(songs, page, pagesize); 
    foreach(var song in pagedList)
          artists.Add(artistRepository.GetArtistBySongID(song.ID));
    ViewData["songs"] = pagedList; 
    ViewData["artists"] = artists;
