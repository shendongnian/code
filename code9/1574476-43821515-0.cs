    var genresTracks = tracks.SelectMany(track=>track.Genres, (track, genre)=> new 
                             { 
                                 Track = track, 
                                 Genre = genre
                             })
                             .GroupBy(tg=>tg.genre)
                             .Select(gr=>new 
                             {
                                 Genre = gr.Key, 
                                 Tracks = gr.Select(x=>x.Track)
                             });
    foreach(var genreTracks in genresTracks)
    {
        var tracksCsv = string.Join(",", genreTracks.Tracks);
        Console.WriteLine($"{genreTracks.Genre} - {tracksCsv}");
    }
